using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{
    public int playerSpeed;
    private float horizontaInput;
    private Rigidbody2D rigidBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); // Pega o componente rigiBody2D
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.linearVelocity = new Vector2(horizontaInput * playerSpeed * Time.fixedDeltaTime, rigidBody.linearVelocity.y); // Movimenta o player
    }
    public void Move(InputAction.CallbackContext context) // Pega o input do playrt (A ou D) num valor de -1 ou 1
    {
        horizontaInput = context.ReadValue<Vector2>().x;
    }
}
