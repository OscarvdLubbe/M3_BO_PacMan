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
    public TextMeshProUGUI count;
    public Image orb;
    public float transitionLength = 3f;
    public GameObject[] ghost;

    void Start()
    {
        ghost = GameObject.FindGameObjectsWithTag("Enemy");
        Text0();
        for (int i = 0; i < ghost.Length; i++)
        {
            ghost[i].SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (closed == false && collider.gameObject.CompareTag("Player")) 
        {
            MazeGenrationTutorial.Instance.Regenerate();
            followCam.Priority = 5;
            zoomOutCam.Priority = 20;
            closed = true;
            StartCoroutine(Text());
            for (int i = 0; i < ghost.Length; i++)
            {
                ghost[i].SetActive(true);
            }

        }
    }

    void TextFade()
    {
        text.CrossFadeAlpha(0f, transitionLength, false);
    }

    void Text0()
    {
        text.CrossFadeAlpha(0f, 0f, false);
        count.CrossFadeAlpha(0f, 0f, false);
        orb.CrossFadeAlpha(0f, 0f, false);
    }

    void TextAppear()
    {
        text.CrossFadeAlpha(1f, transitionLength, false);
        count.CrossFadeAlpha(1f, transitionLength / 4, false);
        orb.CrossFadeAlpha(1f, transitionLength / 4, false);
    }

    IEnumerator Text()
    {
        yield return new WaitForSeconds(2f);
        TextAppear();
        yield return new WaitForSeconds(3f);
        TextFade();
    }
}
