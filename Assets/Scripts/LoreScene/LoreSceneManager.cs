using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoreSceneManager : MonoBehaviour
{
    public Image Transitioner;
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    public GameObject Image5;
    public float TransitionLength= 1f;
    public bool done = false;
    
    void Start()
    {
        Image2.SetActive(false);
        Image3.SetActive(false);
        Image4.SetActive(false);
        Image5.SetActive(false);

        StartCoroutine(LoreSequence());

    }

    void Update()
    {

    }

    IEnumerator LoreSequence()
    {
        Invoke(nameof(TransitionFade), 0f);
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        while (!Input.GetKeyUp(KeyCode.Return))
        {
            yield return null;
        }
        Invoke(nameof(TransitionAppear), 0f);
        yield return new WaitForSeconds(TransitionLength);
        Image1.SetActive(false);
        Image2.SetActive(true);
        Invoke(nameof(TransitionFade), 0f);
        yield return new WaitForSeconds(TransitionLength);
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        while (!Input.GetKeyUp(KeyCode.Return))
        {
            yield return null;
        }
        Invoke(nameof(TransitionAppear), 0f);
        yield return new WaitForSeconds(TransitionLength);
        Image2.SetActive(false);
        Image3.SetActive(true);
        Invoke(nameof(TransitionFade), 0f);
        yield return new WaitForSeconds(TransitionLength);
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        while (!Input.GetKeyUp(KeyCode.Return))
        {
            yield return null;
        }
        Invoke(nameof(TransitionAppear), 0f);
        yield return new WaitForSeconds(TransitionLength);
        Image3.SetActive(false);
        Image4.SetActive(true);
        Invoke(nameof(TransitionFade), 0f);
        yield return new WaitForSeconds(TransitionLength);
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        while (!Input.GetKeyUp(KeyCode.Return))
        {
            yield return null;
        }
        Invoke(nameof(TransitionAppear), 0f);
        yield return new WaitForSeconds(TransitionLength);
        Image4.SetActive(false);
        Image5.SetActive(true);
        Invoke(nameof(TransitionFade), 0f);
        yield return new WaitForSeconds(TransitionLength);
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            yield return null;
        }
        while (!Input.GetKeyUp(KeyCode.Return))
        {
            yield return null;
        }
        Invoke(nameof(TransitionAppear), 0f);
        yield return new WaitForSeconds(TransitionLength);
        MainGameManager.Instance.bools[0] = true;
        MainGameManager.Instance.UpdateFile();
        SceneManager.LoadScene("LevelSelect");   
    }

    void TransitionFade()
    {
        Transitioner.CrossFadeAlpha(0f, TransitionLength, false);
    }

    void TransitionAppear()
    {
        Transitioner.CrossFadeAlpha(1f, TransitionLength, false);
    }
}
