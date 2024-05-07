using UnityEngine;

// Script responsible for moving AI's paddle so it can bounce the ball 

public class AI_Paddle : MonoBehaviour
{
    private bool ball_On_Players_side;

    [SerializeField] private float paddle_Speed;

    [SerializeField] private Transform ball_Transform, paddle_Transform;

    [SerializeField] private Rigidbody2D paddle_Rigidbody2D;

    // Setting proper difficulty level by using static variable from Difficulty_Level class

    private void Awake()
    {
        switch (Difficulty_Level.difficulty_Level)
        {
            case 1: paddle_Speed = 8; break;
            case 2: paddle_Speed = 12; break;
            case 3: paddle_Speed = 16; break;
            default:break;
        }
    }

    private void FixedUpdate()
    {
        Track_The_Ball();
    }

    // Firstly methode checks if ball is on AI's side of 'table'...

    private void Track_The_Ball()
    {
        Check_If_Ball_On_Players_Side();
            
        if (ball_On_Players_side == false)
        {
            Move_In_Proper_Direction();
        }
        else
            paddle_Rigidbody2D.velocity = Vector3.zero;
    }

    //... and then moves the paddle depending on the ball's y-position (using velocity dependent on difficulty level)

    private void Move_In_Proper_Direction()
    {
        if (ball_Transform.position.y - 0.5 > paddle_Transform.position.y)
        {
            paddle_Rigidbody2D.velocity = new Vector2(0, paddle_Speed);
        }
        else if (ball_Transform.position.y + 0.5 < paddle_Transform.position.y)
        {
            paddle_Rigidbody2D.velocity = new Vector2(0, -paddle_Speed);
        }
        else
        {
            paddle_Rigidbody2D.velocity = Vector3.zero;
        }
    }

    private void Check_If_Ball_On_Players_Side()
    {
        if (ball_Transform.position.x <= 0)
        {
            ball_On_Players_side = true;
        }
        else
        {
            ball_On_Players_side = false;
        }
    }
}
