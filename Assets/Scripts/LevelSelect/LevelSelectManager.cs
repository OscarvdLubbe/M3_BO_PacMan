using UnityEngine;
using UnityEngine.UI;
public class LevelSelectManager : MonoBehaviour
{
    public GameObject outpost2;
    public GameObject castle;
    public Image filler;
    void Start()
    {
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
    }
}
