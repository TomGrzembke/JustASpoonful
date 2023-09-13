using Cinemachine;
using System.Collections;
using UnityEngine;

namespace JustASpoonful
{
    /// <summary> Handles 1 specific room switch outside of the normal room gameflow </summary>
    public class SpecialRoomTransition : MonoBehaviour
    {
        [SerializeField] RoomTransitionManager roomTransiManager;
        [SerializeField] CinemachineVirtualCamera roomCam;
        [SerializeField] CinemachineVirtualCamera transiCam;
        [SerializeField] CinemachineBrain cMBrain;

        public void ToSpecialRoom(bool condition)
        {
            if (condition)
                StartCoroutine(ToRoom());
            else
                StartCoroutine(FromRoom());
        }

        IEnumerator ToRoom()
        {
            roomTransiManager?.SetActiveArrows(false);
            transiCam.Priority = roomTransiManager.currentHighestCamPrio + 1;

            yield return null;
            yield return new WaitUntil(() => !cMBrain.IsBlending);

            transiCam.Priority = 0;
            roomCam.Priority = roomTransiManager.currentHighestCamPrio + 1;
        }
        IEnumerator FromRoom()
        {
            roomTransiManager?.SetActiveArrows(true);
            roomCam.Priority = 0;
            transiCam.Priority = roomTransiManager.currentHighestCamPrio + 1;

            yield return null;
            yield return new WaitUntil(() => !cMBrain.IsBlending);

            transiCam.Priority = 0;
        }
    }
}
