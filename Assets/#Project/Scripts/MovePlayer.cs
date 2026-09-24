using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{   
    private const string ACTION_MAP = "CircleActions";
    private const string ACTION_MOVE = "Move";

    [SerializeField]private float speed = 5f;

    [SerializeField] private InputActionAsset inputActions;
    private InputAction move;
    private bool isOnMove = false;

    private void Awake()
    {
       move = inputActions.FindActionMap(ACTION_MAP).FindAction(ACTION_MOVE);
       move.started += ctx => {OnMoveStart(ctx);};
       move.canceled += ctx => {OnMoveCancel(ctx);};
    } 
    private void Update()
    {
        if (isOnMove)
        {
            Move();
        }
    } 

    void OnEnable(){
        inputActions.FindActionMap(ACTION_MAP).Enable();
    }

    void OnDisable(){
        inputActions.FindActionMap(ACTION_MAP).Disable();
    }

    private void OnMoveCancel(InputAction.CallbackContext ctx)
    {
        isOnMove = false;
    }
    private void OnMoveStart(InputAction.CallbackContext ctx)
    {
        isOnMove = true;
    }

    void Move()
    {
        Vector2 mvt = Time.deltaTime * speed * move.ReadValue<float>() * Vector2.right;
        transform.Translate(mvt);
    }
}
