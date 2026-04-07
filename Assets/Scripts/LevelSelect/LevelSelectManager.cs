using UnityEngine;
using UnityEngine.UI;
public class LevelSelectManager : MonoBehaviour
{
    public GameObject outpost2;
    public GameObject castle;
    public Image filler;
    public Image transitioner;
    void Start()
    {
        Time.timeScale = 1;
        filler.fillAmount = 1f; 
        outpost2.SetActive(false);
        castle.SetActive(false);

        if (MainGameManager.Instance.bools[1] == true)
        {
            outpost2.SetActive(true);
            filler.fillAmount = 0.64f;
        }
        if (MainGameManager.Instance.bools[2] == true)
        {
            castle.SetActive(true);
            filler.fillAmount = 0f;
        }
        TransitionFade();
    }
    void TransitionFade()
    {
        transitioner.CrossFadeAlpha(0f, 3f, false);
    }
}
