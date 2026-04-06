using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLevelSelect : MonoBehaviour
{
    public Transform[] points;
    public float speed = 200f;
    public GameObject[] E;
    int index = 0;
    void Start()
    {
        E[0].SetActive(false);
        E[1].SetActive(false);
        E[2].SetActive(false);
    }
    void Update()
    {
        if(MainGameManager.Instance.bools[1] == true && MainGameManager.Instance.bools[2] == false)
        {
            index = Mathf.Clamp(index, 0, 2);
        }
        if(MainGameManager.Instance.bools[1] == true && MainGameManager.Instance.bools[2] == true)
        {
            index = Mathf.Clamp(index, 0, 3);
        }

        if (Input.GetKeyDown(KeyCode.D) && index < points.Length - 1)
            index++;

        if (Input.GetKeyDown(KeyCode.A) && index > 0)
            index--;

        transform.position = Vector3.Lerp(
            transform.position,
            points[index].position,
            speed * Time.deltaTime
        );
        if (index == 0)
        {
            E[0].SetActive(false);
            E[1].SetActive(false);
            E[2].SetActive(false);
        }
        if (index == 1)
        {
            E[0].SetActive(true);
            E[1].SetActive(false);
            E[2].SetActive(false);
        }
        if (index == 2)
        {
            E[0].SetActive(false);
            E[1].SetActive(true);
            E[2].SetActive(false);
        }
        if (index == 3)
        {
            E[0].SetActive(false);
            E[1].SetActive(false);
            E[2].SetActive(true);
        }
        //lvl load
        if (index == 1 && Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("TutorialMaze");
        }
        if (index == 2 && Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("TutorialMaze");
        }
        if (index == 3 && Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("TutorialMaze");
        }
    }

}