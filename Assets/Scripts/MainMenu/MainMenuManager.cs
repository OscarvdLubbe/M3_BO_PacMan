using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Image LastOrb;

    public GameObject Text;
    public GameObject ButtonStart;
    public GameObject ButtonSettings;
    public GameObject ButtonExit;
    public Image Transitioner;
    public GameObject TransitionerGO;
    [SerializeField] private float duration = 4f;
    private float timer = 0f;
    private bool done = false;
    void Start()
    {
        Transitioner.CrossFadeAlpha(0f, 0f, false);
        TransitionerGO.SetActive(false);
        LastOrb.fillAmount = 0;
        Text.SetActive(false);
        ButtonStart.SetActive(false);
        ButtonSettings.SetActive(false);
        ButtonExit.SetActive(false);
        Time.timeScale = 1;
    }


    void Update()
    {
        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / duration);

        LastOrb.fillAmount = t;

        if(t==1 && done == false)
        {
            Text.SetActive(true);
            Invoke(nameof(ButtonStartShow), 1f); // nog bij elke button een sound afspelen? N.
            Invoke(nameof(ButtonSettingsShow), 2f);
            Invoke(nameof(ButtonExitShow), 3f);
            done = true;
        }
    }

    void ButtonStartShow()
    {
        ButtonStart.SetActive(true);
    }

    void ButtonSettingsShow()
    {
        ButtonSettings.SetActive(true);
    }

    void ButtonExitShow()
    {
        ButtonExit.SetActive(true);
    }

    public void StartB()
    {
        StartCoroutine(Fade());

    }

    public void SettingsB()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator Fade()
    {
        TransitionerGO.SetActive(true);
        yield return null;
        TransitionAppear();
        yield return new WaitForSeconds(2f);
        if(MainGameManager.Instance.bools[0] == false)
        {
            SceneManager.LoadScene("Lore");
        }
        if(MainGameManager.Instance.bools[0] == true)
        {
            SceneManager.LoadScene("LevelSelect");
        }
    }

    void TransitionAppear()
    {
        Transitioner.CrossFadeAlpha(1f, 2f, false);
    }
}
