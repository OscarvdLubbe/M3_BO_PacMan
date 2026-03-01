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
    [SerializeField] private float duration = 4f;
    private float timer = 0f;
    void Start()
    {
        LastOrb.fillAmount = 0;
        Text.SetActive(false);
        ButtonStart.SetActive(false);
        ButtonSettings.SetActive(false);
        ButtonExit.SetActive(false);
    }


    void Update()
    {
        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / duration);

        LastOrb.fillAmount = t;

        if(t==1)
        {
            Text.SetActive(true);
            Invoke(nameof(ButtonStartShow), 1f); // nog bij elke button een sound afspelen? N.
            Invoke(nameof(ButtonSettingsShow), 2f);
            Invoke(nameof(ButtonExitShow), 3f);
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
        SceneManager.LoadScene("Maze"); // nog een tutorial scene tussen? of lore? N.
    }

    public void SettingsB()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
