using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour
{
    int x;
    int y;
    [SerializeField] private bool isRepeatedMovement = true;
    [SerializeField] private float moveDuration = 0.1f;
    [SerializeField] private float gridSize = 1f;

    private bool isMoving = false;

	private void Start()
	{
		
	}
    private void Update()
    {
        if (isMoving) return;

        System.Func<KeyCode, bool> inputFunction =
            isRepeatedMovement ? Input.GetKey : Input.GetKeyDown;

        if (inputFunction(KeyCode.W))
        {
            StartCoroutine(Move(Vector2.up));
        }
        else if (inputFunction(KeyCode.D))
        {
            StartCoroutine(Move(Vector2.right));
        }
        else if (inputFunction(KeyCode.A))
        {
            StartCoroutine(Move(Vector2.left));
        }
        else if (inputFunction(KeyCode.S))
        {
            StartCoroutine(Move(Vector2.down));
        }

    }

    private IEnumerator Move(Vector2 direction)
    {
        isMoving = true;

        Vector2 startPosition = transform.position;
        Vector2 endPosition = startPosition + (direction * gridSize);

        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float percent = elapsedTime / moveDuration;

            transform.position = Vector2.Lerp(startPosition, endPosition, percent);
            yield return null;
        }

        transform.position = endPosition;
        isMoving = false;
    }
	void OnCollisionEnter(Collision colider)
	{
		if (gameObject.CompareTag("Wall"))
		{
			
		}
	}
}
