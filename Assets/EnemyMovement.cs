using System.Collections;

using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    [SerializeField] private float rayDistance = 1f;
    [SerializeField] private float gridSize = 1f;
    [SerializeField] private float moveDuration = 0.2f;
    int currentDirection = 0;
    //bool RayCastHit = false;
    private bool isMoving = false;
    private Vector3[] directions = new Vector3[]
    {
        Vector3.up,
        Vector3.down,
        Vector3.left,
        Vector3.right,
    };
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (isMoving) return;

        Vector3 direction = directions[currentDirection];
        TryMove(direction);
    }

    private void TryMove(Vector3 direction)
    {
        if (CanMove(direction))
        {
            StartCoroutine(Move(direction));
        }
        else
        {
            currentDirection = Random.Range(0,directions.Length);
        }
    }
    // als raycast geraakt word kies andere richting loop to nog een muur en repeat
    private bool CanMove(Vector3 direction)
    {
        Vector3 origin = transform.position;
        RaycastHit hit;
        
        if (Physics.Raycast(origin,direction, out hit, rayDistance))

        if (hit.collider != null)
        {
            if (hit.collider.isTrigger)
                return true;

            Debug.DrawRay(origin, direction * rayDistance, Color.red, 0.5f);
            return false;
        }
        Debug.DrawRay(origin, direction * rayDistance, Color.green, 0.5f);
        return true;
    }

    private IEnumerator Move(Vector3 direction)
    {
        isMoving = true;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + direction * gridSize;

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
}