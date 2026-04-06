using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace TutorialMaze
{
    public class TutorialManager : MonoBehaviour
    {
        public static TutorialManager Instance { get; private set; }
        public TextMeshProUGUI text;
        public Image transitioner;
        public float transitionLength = 1f;
        public float orbs;
        public bool paused;
        public GameObject pauseMenu;
        public GameObject[] ghosts;
        void Start()
        {
            Instance = this;
            orbs = 0;
            TransitionFade();
            text.text = 10 + "/" + orbs;
            paused = false;
            pauseMenu.SetActive(false);
            ghosts = GameObject.FindGameObjectsWithTag("Enemy");
            Time.timeScale = 1;
        }
        void TransitionFade()
        {
            transitioner.CrossFadeAlpha(0f, transitionLength, false);
        }

        void TransitionAppear()
        {
            transitioner.CrossFadeAlpha(1f, transitionLength, false);
        }

        public void OrbCounter()
        {
            orbs++;
            text.text = 10 + "/" + orbs;
            if (10 <= orbs)
            {
                Finish();
                ghosts = GameObject.FindGameObjectsWithTag("Enemy");
            }
        }

        public void Finish()
        {
            for (int i = 0; i < ghosts.Length; i++)
            {
                ghosts[i].SetActive(false);
            }
            TransitionAppear();
            MainGameManager.Instance.bools[1] = true;
            MainGameManager.Instance.UpdateFile();
            SceneManager.LoadScene("LevelSelect");
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                paused = !paused;

                if (paused)
                {
                    Time.timeScale = 0f;
                    pauseMenu.SetActive(true);
                }
                else
                {
                    Time.timeScale = 1f;
                    pauseMenu.SetActive(false);
                }
            }
            ghosts = GameObject.FindGameObjectsWithTag("Enemy");
        }
        public void MainMenu()
        {
            SceneManager.LoadScene("StartScreen");
        }
        public void LevelSelect()
        {
            SceneManager.LoadScene("LevelSelect");
        }
    }
}