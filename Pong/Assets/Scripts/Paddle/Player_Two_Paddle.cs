using UnityEngine;
using UnityEngine.InputSystem;

// Script does everything which player one paddle script does but using arrows instead of 'W' and 'S'

public class Player_Two_Paddle : MonoBehaviour
{
    [SerializeField] private int paddle_Speed;

    private Vector2 move_Vector;

    [SerializeField] private Transform paddle_Transform;

    [SerializeField] private Rigidbody2D paddle_Rigidbody2D;

    [SerializeField] private AudioSource paddle_Audio_Source;

    private CustomInput input;

    private void Awake()
    {
        input = new CustomInput();
        input.Enable();
        input.Players.Player_Two_Movement.performed += OnMovementPerformed;
        input.Players.Player_Two_Movement.canceled += OnMovementCanceled;
    }

    private void Update()
    {
        if (paddle_Transform.position.y < 4.3 && paddle_Transform.position.y > -4.3)
        {
            paddle_Rigidbody2D.velocity = move_Vector * paddle_Speed;
        }
        else if (paddle_Transform.position.y > 4.3)
        {
            paddle_Transform.position = new Vector2(8, 4.2f);
        }
        else if (paddle_Transform.position.y < -4.3)
        {
            paddle_Transform.position = new Vector2(8, -4.2f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            paddle_Audio_Source.Play();
        }
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        move_Vector = value.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        move_Vector = Vector2.zero; 
    }
}
