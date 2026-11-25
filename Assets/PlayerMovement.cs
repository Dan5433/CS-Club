using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 100000000000000000f;
    [SerializeField] int groundLayer;

    Rigidbody2D rigidbody2d;
    Vector2 movementInput;
    bool onGround;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidbody2d.linearVelocityX = movementInput.x * moveSpeed;

        if (movementInput.y > 0 && onGround)
        {
            rigidbody2d.linearVelocityY = jumpForce;
            onGround = false;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer && collision.GetContact(0).normal == Vector2.up)
        {
            onGround = true;
        }
    }
}