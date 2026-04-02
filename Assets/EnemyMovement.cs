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
    void OnTriggerEnter2D(Collider2D other)
    {
        float RND = Random.Range(0f,1f);
        if (other.gameObject.CompareTag("R"))
        {
            currentDirection = 3;
            //Debug.Log("I am vionlantly being touched");
        }
        else if (other.gameObject.CompareTag("L"))
        {
            currentDirection = 2;
        }
        else if (other.gameObject.CompareTag("U"))
        {
            currentDirection = 0;
        }
        else if (other.gameObject.CompareTag("D"))
        {
            currentDirection = 1;
        }
        else if (other.gameObject.CompareTag("RD"))
        {
            if (RND <= 0.5f)
            {
                currentDirection = 3;
            }
            else if (RND >= 0.5f)
            {
                currentDirection = 1;
            }
        }
        else if (other.gameObject.CompareTag("LD"))
        {
            if (RND <= 0.5f)
            {
                currentDirection = 2;
            }
            else if (RND >= 0.5f)
            {
                currentDirection = 1;
            }
        }
        else if (other.gameObject.CompareTag("UR"))
        {
            if (RND <= 0.5f)
            {
                currentDirection = 3;
            }
            else if (RND >= 0.5f)
            {
                currentDirection = 1;
            }
        }
        else if (other.gameObject.CompareTag("UL"))
        {
            if (RND <= 0.5f)
            {
                currentDirection = 0;
            }
            else if (RND >= 0.5f)
            {
                currentDirection = 2;
            }
        }
        else if (other.gameObject.CompareTag("LRD"))
        {
            if (RND <= 0.33f)
            {
                currentDirection = 2;
            }
            else if (RND >= 0.66f)
            {
                currentDirection = 3;
            }
            else
            {
                currentDirection = 1;
            }
        }
        else if (other.gameObject.CompareTag("UDR"))
        {
            if (RND <= 0.33f)
            {
                currentDirection = 0;
            }
            else if (RND >= 0.66f)
            {
                currentDirection = 1;
            }
            else
            {
                currentDirection = 3;
            }
        }
        else if (other.gameObject.CompareTag("UDL"))
        {
            if (RND <= 0.33f)
            {
                currentDirection = 0;
            }
            else if (RND >= 0.66f)
            {
                currentDirection = 1;
            }
            else
            {
                currentDirection = 2;
            }
        }
        else if (other.gameObject.CompareTag("ULR"))
        {
            if (RND <= 0.33f)
            {
                currentDirection = 0;
            }
            else if (RND >= 0.66f)
            {
                currentDirection = 2;
            }
            else
            {
                currentDirection = 3;
            }
        }
        else if (other.gameObject.CompareTag("UDLR"))
        {
            currentDirection = Random.Range(0,directions.Length);
        }
    }
}