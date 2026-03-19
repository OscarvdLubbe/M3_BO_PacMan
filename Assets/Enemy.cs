using UnityEngine;
using System.Collections.Generic;
public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    // public GameObject debugTransforms;
    private List<Transform> points = new List<Transform>();
    private SpriteRenderer spriteRenderer;
    private int i;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // debugTransforms.transform.Get
    }

public void AddPoint(Transform point )
    {
        points.Add(point);
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, points[i].position) < 0.25f)
        {
            i++;

            if (i == points.Count)
            {
                i = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        //spriteRenderer.flipX = (transform.position.x - points[i].position.x) < 0f;
    }
}
