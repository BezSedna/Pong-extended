using UnityEngine;

// Script resposible for ball physics (correct bouncing, acceleration)

public class Ball_Movement : MonoBehaviour
{
    public readonly int base_Ball_Speed = 15;

    public float current_Ball_Speed;

    [SerializeField][Range(0.1f, 1.5f)] private float ball_Acceleraion;

    public Vector2 last_Ball_Position; 

    private Vector2 current_Ball_Position, ball_Direction; 

    [SerializeField] private Transform ball_Transform;

    [SerializeField] private Rigidbody2D ball_Rigidbody2D;

    // Methode checks if ball hits Boundary or Paddle to set proper bounce vector 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Paddle"))
        {
            // Firstly methode stops the ball...

            ball_Rigidbody2D.velocity = Vector2.zero;

            //..., creates direction vector by using last ball position and current ball position...

            current_Ball_Position = new Vector2(ball_Transform.position.x, ball_Transform.position.y);

            ball_Direction = 
                new Vector2(last_Ball_Position.x - current_Ball_Position.x,
                current_Ball_Position.y - last_Ball_Position.y);

            //... and then adds velocity to ball by pushing it 

            ball_Rigidbody2D. AddForce(ball_Direction.normalized * current_Ball_Speed, ForceMode2D.Impulse);

            // Updating Ball data 

            last_Ball_Position = current_Ball_Position;

            current_Ball_Speed += ball_Acceleraion;
        }
        else if (collision.collider.CompareTag("Boundary"))
        {
            // Same thing as in earlier if statment (excluding acceleration of the ball)

            ball_Rigidbody2D.velocity = Vector2.zero;

            current_Ball_Position = new Vector2(ball_Transform.position.x, ball_Transform.position.y);
            ball_Direction = 
                new Vector2(current_Ball_Position.x - last_Ball_Position.x,
                last_Ball_Position.y - current_Ball_Position.y);
            
            ball_Rigidbody2D.
                AddForce(ball_Direction.normalized * current_Ball_Speed, ForceMode2D.Impulse);
            
            last_Ball_Position = current_Ball_Position;
        }
    }
}