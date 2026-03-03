using UnityEngine;
using UnityEngine.UI;

public class LoreSceneManager : MonoBehaviour
{
    public GameObject Transitioner;
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    public GameObject Image5;
    public float TransitionLength;
    
    void Start()
    {
        Image2.SetActive(false);
        Image3.SetActive(false);
        Image4.SetActive(false);
        Image5.SetActive(false);

        Invoke(nameof(TransitionFade), 1f);
        Invoke(nameof(ShowImg01), 2f);
        Invoke(nameof(TransitionAppear), 5f);
        

    }

    void Update()
    {
        
    }

    void TransitionFade()
    {
        
    }

    void TransitionAppear()
    {
        
    }

    void ShowImg01()
    {
        
    }
}
