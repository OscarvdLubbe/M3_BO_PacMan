using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.UI;

namespace TutorialMaze
{
    public class CameraTrigger : MonoBehaviour
    {
        public Image transitioner;
        public float transitionLength = 1f;
        void Start()
        {
            TransitionFade();
        }
        void TransitionFade()
        {
            transitioner.CrossFadeAlpha(0f, transitionLength, false);
        }

        void TransitionAppear()
        {
            transitioner.CrossFadeAlpha(1f, transitionLength, false);
        }
    }
}