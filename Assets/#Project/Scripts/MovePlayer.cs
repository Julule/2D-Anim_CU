using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class MovePlayer : MonoBehaviour
{   
    private const string ACTION_MAP = "CircleActions";
    private const string ACTION_MOVE = "Move";
    public const string ANIMATION_SPEED = "Speed"; 

    [SerializeField]private float speed = 5f;

    [SerializeField] private InputActionAsset inputActions;
    private InputAction move;
    private bool isOnMove = false;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    Vector2 startPosition;


    private void Awake()
    {
       move = inputActions.FindActionMap(ACTION_MAP).FindAction(ACTION_MOVE);
       move.started += ctx => {OnMoveStart(ctx);};
       move.canceled += ctx => {OnMoveCancel(ctx);};

       animator = GetComponent<Animator>();

       spriteRenderer = GetComponent<SpriteRenderer>();
       startPosition = transform.position;

    } 
    private void Update()
    {
        if (isOnMove)
        {
            Move();
        }

        if (transform.position.y < -2)
        {
            transform.position = startPosition;
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
        animator.SetFloat(ANIMATION_SPEED, 0f);
    }
    private void OnMoveStart(InputAction.CallbackContext ctx)
    {
        isOnMove = true;
    }

    void Move()
    {
        float mvtSpeed = speed * move.ReadValue<float>();
        Vector2 mvt = Time.deltaTime * mvtSpeed * Vector2.right;

        spriteRenderer.flipX = mvtSpeed < 0 ;

        animator.SetFloat(ANIMATION_SPEED, Mathf.Abs(mvtSpeed));

        transform.Translate(mvt);

    }
}
