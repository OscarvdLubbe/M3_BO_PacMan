using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainGameManager : MonoBehaviour
{
    public bool[] bools = {false, false, false, false};

    public static MainGameManager Instance { get; private set; }

    private string fileName = "data.sav";

    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        bool FileExists = File.Exists(fileName);
        if(FileExists == true)
        {
            bools = System.Array.ConvertAll(File.ReadAllLines(fileName), bool.Parse);
        }
        if(FileExists == false)
        {
            File.WriteAllLines(fileName, System.Array.ConvertAll(bools, b => b.ToString()));
        }
        SceneManager.LoadScene("StartScreen");
    }    

    void Update()
    {
        
    }

    public void UpdateFile()
    {
        File.WriteAllLines(fileName, System.Array.ConvertAll(bools, b => b.ToString()));
    }
}
