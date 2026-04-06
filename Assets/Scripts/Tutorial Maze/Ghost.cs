using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    public float moveDuration = 0.15f;
    public float rayDistance = 1f;

    private float gridSize;
    public SpriteRenderer tile;

    private bool isMoving = false;

    private Transform player;
    private SpriteRenderer sr;

    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite idleSprite;

    private Vector3 lastDirection = Vector3.zero;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        gridSize = tile.bounds.size.x;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (isMoving) return;

        Vector3 bestDirection = Vector3.zero;
        float bestScore = Mathf.Infinity;

        Vector3[] directions = new Vector3[]
        {
            Vector3.up,
            Vector3.down,
            Vector3.left,
            Vector3.right
        };

        foreach (Vector3 dir in directions)
        {
            if (!CanMove(dir)) continue;

            Vector3 nextPos = transform.position + dir * gridSize;

            float score = Vector3.Distance(nextPos, player.position);

            if (dir == -lastDirection)
                score += 1.5f;

            if (score < bestScore)
            {
                bestScore = score;
                bestDirection = dir;
            }
        }

        if (bestDirection != Vector3.zero)
        {
            lastDirection = bestDirection;
            StartCoroutine(Move(bestDirection));
        }
    }

    bool CanMove(Vector3 direction)
    {
        Vector3 origin = transform.position;
        RaycastHit hit;

        if (Physics.Raycast(origin, direction, out hit, rayDistance))
        {
            if (hit.collider.isTrigger)
                return true;

            return false;
        }

        return true;
    }

    IEnumerator Move(Vector3 direction)
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

            Vector3 pos = transform.position;
            pos.z = 0f;
            transform.position = pos;

            yield return null;
        }

        transform.position = endPosition;

        Vector3 finalPos = transform.position;
        finalPos.z = 0f;
        transform.position = finalPos;

        UpdateSprite(direction);

        isMoving = false;
    }

    void UpdateSprite(Vector3 movement)
    {
        if (movement == Vector3.zero)
        {
            sr.sprite = idleSprite;
            return;
        }

        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            sr.sprite = movement.x > 0 ? rightSprite : leftSprite;
        else
            sr.sprite = movement.y > 0 ? upSprite : downSprite;
    }
}