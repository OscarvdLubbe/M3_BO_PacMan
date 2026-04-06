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
        public bool won;
        void Start()
        {
            Instance = this;
            orbs = 0;
            TransitionFade();
            text.text = 10 + "/" + orbs;
            won =false;
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
            }
        }

        public void Finish()
        {
            TransitionAppear();
                    MainGameManager.Instance.bools[1] = true;
                    MainGameManager.Instance.UpdateFile();
                    SceneManager.LoadScene("LevelSelect"); 
        }
    }
}