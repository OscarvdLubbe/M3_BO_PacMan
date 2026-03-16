using UnityEngine;
using Unity.Cinemachine;

public class MazeEntranceCloser : MonoBehaviour
{
    public bool closed = false;
    public CinemachineCamera followCam;
    public CinemachineCamera zoomOutCam;

    void OnTriggerEnter(Collider collider)
    {
        if(closed == false)
        {
            MazeGenrationTutorial.Instance.ToggleO();
            followCam.Priority = 5;
            zoomOutCam.Priority = 20;
            closed = true;
            Destroy(this.gameObject);
        }
    }
}
