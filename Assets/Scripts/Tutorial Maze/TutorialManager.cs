using UnityEngine;
using Unity.Cinemachine;

namespace TutorialMaze
{
    public class CameraTrigger : MonoBehaviour
    {
        public CinemachineCamera followCam;
        public CinemachineCamera zoomOutCam;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                followCam.Priority = 5;
                zoomOutCam.Priority = 20;
            }
        }
    }
}