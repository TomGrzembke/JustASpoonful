using UnityEngine;
using Cinemachine;

namespace JustASpoonful
{
    /// <summary> Handles the basic cam movement for the rooms</summary>
    public class RoomTransitionManager : MonoBehaviour
    {
        [SerializeField] CinemachineVirtualCamera[] roomCams;
        [SerializeField] GameObject[] inputArrows;
        int activeRoomCamIndex;

        public void RoomInput(int nextState)
        {
            activeRoomCamIndex = GetCurrentCamIndex();

            roomCams[activeRoomCamIndex].Priority--;
            roomCams[activeRoomCamIndex + nextState].Priority++;

            activeRoomCamIndex = GetCurrentCamIndex();
            inputArrows[0].SetActive(activeRoomCamIndex != 0);
            inputArrows[1].SetActive(activeRoomCamIndex != roomCams.Length -1);
        }

        int GetCurrentCamIndex()
        {
            for (int i = 0; i < roomCams.Length; i++)
            {
                int currentCamPrio = roomCams[i].Priority;
                if (currentCamPrio > roomCams[activeRoomCamIndex].Priority)
                    activeRoomCamIndex = i;
            }
            return activeRoomCamIndex;
        }
    }
}
