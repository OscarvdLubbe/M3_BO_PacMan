

using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
           Debug.Log("Waypoints script has started");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider col)
    {
          //  Debug.Log(col.gameObject.name); 
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("aaaaaaaaaaaaaaaaaaaaa"); 
        }
    }
}
