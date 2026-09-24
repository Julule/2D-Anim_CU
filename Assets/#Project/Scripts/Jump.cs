using System;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] InputActionAsset circleActions;
    private const string ACTION_MAP = "CircleActions";
    private const string ACTION_JUMP = "Jump";
    private InputAction jump;
    private Rigidbody2D rb;
    [SerializeField] float jumpForce = 10f;
    
    
    private void Awake()
    {
        jump = circleActions.FindActionMap(ACTION_MAP).FindAction(ACTION_JUMP);
        jump.performed += ctx => {Jumping(ctx);};
    }


    private void OnEnable()
    {
        circleActions.FindActionMap(ACTION_MAP).Enable();
    }

    private void Disable()
    {
        circleActions.FindActionMap(ACTION_MAP).Disable();
    }
    void Jumping(InputAction.CallbackContext context)
    {
        rb = GetComponent<Rigidbody2D>();
        float jumpAction = jump.ReadValue<float>();
        rb.AddForce(Vector2.up * jumpForce * jumpAction);
    }
}
