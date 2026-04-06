using TutorialMaze;
using UnityEngine;

public class Orb : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            TutorialManager.Instance.OrbCounter();
            Destroy(gameObject);
        }
    }
}
