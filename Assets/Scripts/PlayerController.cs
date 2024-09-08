using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
    public float walkSpeed = 5f;
    Vector2 moveInput;

    public bool IsMoving { get; private set; }

    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
    }

    private void FixedUpdate() {
        //rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
        rb.velocity = new Vector2(moveInput.x * walkSpeed, moveInput.y * walkSpeed);
    }

    public void OnMove(InputAction.CallbackContext context) {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;
    }
}
