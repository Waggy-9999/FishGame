using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public float speed;
    private Vector2 move;
    private InputManager playerInput;
    private InputAction dashAction;
    private InputAction moveAction;

    public float dashSpeed;
    public float dashDuration;
    private bool isDashing;
    private float dashTime;

    private void OnEnable()
    {
        playerInput = new InputManager();
        playerInput.Enable();
        dashAction = playerInput.Player.Dash;
        moveAction = playerInput.Player.Move;
        dashAction.Enable();
        moveAction.Enable();
        dashAction.performed += OnDash;
        moveAction.performed += OnMove;

    }

    private void OnDisable()
    {
        playerInput.Disable();
        dashAction.Disable();
        moveAction.Disable();
        dashAction.performed -= OnDash;
        moveAction.performed -= OnMove;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (!isDashing)
        {
            isDashing = true;
            dashTime = dashDuration;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isDashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            Dash();
        }
        else
        {
            movePlayer();
        }
    }

    public void movePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);
        if (Vector3.Distance(transform.position, Vector3.zero) < 70)
        {
            transform.position += movement * speed * Time.deltaTime;
        }
        else if (Vector3.Distance(transform.position, Vector3.zero) > 70)
        {
            Vector3 towardsOrigin = Vector3.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);
            transform.position = towardsOrigin;
        }

        // This makes it so player looks at target direction
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }
    }

    public void Dash()
    {
        Vector3 dashMovement = new Vector3(move.x, 0f, move.y);
        transform.position += dashMovement * dashSpeed * Time.deltaTime;

        dashTime -= Time.deltaTime;
        if (dashTime <= 0)
        {
            isDashing = false;
        }
    }
}
