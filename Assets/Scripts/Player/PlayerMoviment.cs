using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{
    public int playerSpeed;
    private float horizontaInput;
    private Rigidbody2D rigidBody;
    public float jumpForce;
    private bool jumped = false;
    private SpriteRenderer spriteRender;
    public InputActionAsset InputActions;
    private InputAction moveAction;
    private InputAction jumpAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>(); // Pega o componente rigiBody2D
    }
    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }
    void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }
    void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }

    // Update is called once per frame
    void Update()
    {
        horizontaInput = moveAction.ReadValue<Vector2>().x;
        if (horizontaInput > 0)
        {
            spriteRender.flipX = false;
        }else if (horizontaInput < 0)
        {
            spriteRender.flipX = true;
        }
        rigidBody.linearVelocity = new Vector2(horizontaInput * playerSpeed * Time.fixedDeltaTime, rigidBody.linearVelocity.y); // Movimenta o player
        if (jumpAction.WasPressedThisFrame() & !jumped)
        {
            jumped = true;
            rigidBody.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumped = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        jumped = true;
    }
}
