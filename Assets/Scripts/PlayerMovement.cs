using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody BodyPlayer;

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
    }

    private void FixedUpdate()
    {

        movement = new Vector3(horizontal, vertical, 0).normalized;
        BodyPlayer.linearVelocity = new Vector3(movement.x * Speed, movement.y * Speed, movement.z * Speed) * Time.fixedDeltaTime;
    }
}
