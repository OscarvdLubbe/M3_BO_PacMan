using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class MazeEntranceCloser : MonoBehaviour
{
    public bool closed = false;
    public CinemachineCamera followCam;
    public CinemachineCamera zoomOutCam;
    public TextMeshProUGUI text;
    public float transitionLength = 3f;

    void Start()
    {
        Text0();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (closed == false)
        {
            MazeGenrationTutorial.Instance.Regenerate();
            followCam.Priority = 5;
            zoomOutCam.Priority = 20;
            closed = true;
            StartCoroutine(Text());
        }
    }

    void TextFade()
    {
        text.CrossFadeAlpha(0f, transitionLength, false);
    }

    void Text0()
    {
        text.CrossFadeAlpha(0f, 0f, false);
    }

    void TextAppear()
    {
        text.CrossFadeAlpha(1f, transitionLength, false);
    }

    IEnumerator Text()
    {
        yield return new WaitForSeconds(2f);
        TextAppear();
        yield return new WaitForSeconds(3f);
        TextFade();
    }
}
