using UnityEngine;

using System.Collections;


public class PlayerMovement : MonoBehaviour

{
    private Enemy[] enemies;
    public GameObject waypoint;
    [SerializeField] private float moveDuration = 0.1f;

    [SerializeField] private float rayDistance = 1f;

    private float gridSize;

    public SpriteRenderer tile;

    private bool isMoving = false;

    private void Start()

    {
        gridSize = tile.bounds.size.x;
        enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);

    }

    private void Update()

    {

        if (isMoving) return;

        if (Input.GetKey(KeyCode.W))

        {

            TryMove(Vector3.up);

        }

        else if (Input.GetKey(KeyCode.S))

        {

            TryMove(Vector3.down);

        }

        else if (Input.GetKey(KeyCode.A))

        {

            TryMove(Vector3.left);

        }

        else if (Input.GetKey(KeyCode.D))

        {

            TryMove(Vector3.right);

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = Instantiate(waypoint);
            obj.transform.position = transform.position;
            foreach (Enemy e in enemies)
            {
                e.points.Add(obj.transform);
            }
        }
    }

    private void TryMove(Vector3 direction)

    {
        GameObject obj = Instantiate(waypoint);
        obj.transform.position = transform.position;
        foreach (Enemy e in enemies)
        {
            e.points.Add(obj.transform);
        }
        if (CanMove(direction))

        {

            StartCoroutine(Move(direction));

        }

    }

    private bool CanMove(Vector3 direction)

    {

        Vector3 origin = transform.position;


        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(origin, direction, out hit, rayDistance))
        // if (Physics.Raycast(origin, direction, rayDistance))

        {
            if (hit.collider.isTrigger)
            {
                return true;
            }
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

