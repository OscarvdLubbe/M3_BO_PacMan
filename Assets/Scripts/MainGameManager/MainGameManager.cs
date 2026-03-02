using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameManager : MonoBehaviour
{
    public bool outpostOne = false;
    public bool outpostTwo = false;
    public bool outpostThree = false;
    public static MainGameManager Instance { get; private set; }

    void Start()
    {
        // save files ophalen
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("StartScreen");
    }    

    void Update()
    {
        
    }
}
