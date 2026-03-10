using UnityEngine;

public class Orbs : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter(collision other){
              if(other.GameObject.CompareTag("Player")){
                  GameObject.SetActive(false);
              }
        }
    }
}
