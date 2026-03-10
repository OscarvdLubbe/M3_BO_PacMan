using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{









    // ander movement systeem maken









    int x;
    int y;

    [SerializeField] private bool isRepeatedMovement = true;
    [SerializeField] private float moveDuration = 0.1f;
    [SerializeField] private float gridSize = 1f;

    public Vector3 startPosition;
    public Vector3 endPosition;
    private int position;

    private bool isMoving = false;

    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        ray = new Ray(transform.position, transform.forward);
        CheckForColliders();
    }

    void CheckForColliders()
{
    // Cast a ray upwards
    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, 10f))
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up), Color.red);
        Debug.Log(hit.collider.gameObject.name + " you cannot move forward");
    }
    // Cast a ray rightwards
    else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 10f))
    {
        Debug.Log(hit.collider.gameObject.name + " you cannot move right");
    }
    // Cast a ray leftwards
    else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 10f))
    {
        Debug.Log(hit.collider.gameObject.name + " you cannot move left");
    }
    // Cast a ray downwards
    else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 10f))
    {
        Debug.Log(hit.collider.gameObject.name + " you cannot move backward");
    }
}

    private void Update()
    {
        if (isMoving) return;

        if (Input.GetKey(KeyCode.W))
        {
            StartCoroutine(Move(Vector3.up));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            StartCoroutine(Move(Vector3.right));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            StartCoroutine(Move(Vector3.left));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            StartCoroutine(Move(Vector3.down));
        }
    }

    public IEnumerator Move(Vector3 direction)
    {
        isMoving = true;

        startPosition = transform.position;
        endPosition = startPosition + (direction * gridSize);

        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float percent = elapsedTime / moveDuration;

            transform.position = Vector3.Lerp(startPosition, endPosition, percent);
            yield return null;
        }

        transform.position = endPosition;
        isMoving = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            endPosition = startPosition;
        }
    }
}
