using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D BodyPlayer;

    private float horizontal;
    private float vertical;
    public float Speed = 350;

    private Vector3 movement;

    void Start()
    {


    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.w))
        {
            transform.position += 
        }
    }

    private void FixedUpdate()
    {

        movement = new Vector3(horizontal, vertical, 0).normalized;
        BodyPlayer.linearVelocity = new Vector3(movement.x * Speed, movement.y * Speed, movement.z * Speed) * Time.fixedDeltaTime;
    }
}
