using Cinemachine;
using UnityEngine;

namespace JustASpoonful
{
    /// <summary> Handles the basic cam movement for the rooms</summary>
    public class RoomTransitionManager : MonoBehaviour
    {
        [SerializeField] CinemachineVirtualCamera[] roomCams;
        [SerializeField] GameObject[] inputArrows;
        public int currentHighestCamPrio { get; private set; }
        int activeRoomCamID;

        public void RoomInput(int nextState)
        {
            activeRoomCamID = GetCurrentCamIndex();

            roomCams[activeRoomCamID].Priority = 0;
            roomCams[activeRoomCamID + nextState].Priority++;

            ManageArrowVisibility();
        }

        /// <summary> Gets the index of the cam from the room cam array, which carries the highest prio </summary>
        int GetCurrentCamIndex()
        {
            int currentActiveRoomCamID = 0;
            for (int i = 0; i < roomCams.Length; i++)
            {
                currentHighestCamPrio = roomCams[i].Priority;
                if (currentHighestCamPrio > roomCams[currentActiveRoomCamID].Priority)
                    currentActiveRoomCamID = i;
            }
            return currentActiveRoomCamID;
        }
        void ManageArrowVisibility()
        {
            activeRoomCamID = GetCurrentCamIndex();

            inputArrows[0].SetActive(activeRoomCamID != 0);
            inputArrows[1].SetActive(activeRoomCamID != roomCams.Length - 1);
        }

        public void SetActiveArrows(bool state)
        {
            try
            {
                for (int i = 0; i < inputArrows.Length; i++)
                {
                    inputArrows[i].SetActive(state);
                }
            }
            catch { }
        }

        void OnEnable()
        {
            SetActiveArrows(true);
        }

        void OnDisable()
        {
            SetActiveArrows(false);
        }
    }
}
