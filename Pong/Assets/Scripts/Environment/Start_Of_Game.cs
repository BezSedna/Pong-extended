using UnityEngine;
using Random = UnityEngine.Random;

// Script responsible for starting new round when game begins or when one of players gets a point

public class Start_Of_Game : MonoBehaviour
{
    private int random_Number;

    [SerializeField] public float start_Ball_Speed = 300;

    private Vector2 ball_Direction;

    [SerializeField] private Transform ball_Transform;

    [SerializeField] private Rigidbody2D ball_RigidBody2D;

    [SerializeField] private Ball_Movement ball_Movement;
    
    void Awake()
    {
        Start_New_Round();
    }

    // Setting base ball's data every new round 

    public void Start_New_Round()
    {
        ball_RigidBody2D.velocity = Vector3.zero;

        ball_Transform.position = new Vector3(0, 0);

        Invoke("Push_The_Ball", 1);

        ball_Movement.last_Ball_Position = Vector3.zero;

        ball_Movement.current_Ball_Speed = ball_Movement.base_Ball_Speed;
    }

    // method moves ball form it's start position by using AddForce methode and randomly choosed direction as an argument

    private void Push_The_Ball()
    {
        ball_Direction = Choose_Random_Direction();
        
        ball_RigidBody2D.AddForce(ball_Direction * start_Ball_Speed);
    }

    // methode randomly chooses one of 4 directions 

    private Vector2 Choose_Random_Direction()
    {
        random_Number = Random.RandomRange(0, 4);
        
        switch (random_Number) 
        { 
            case 0: return new Vector2(1, 0.9f);
            case 1: return new Vector2(-1, 0.9f);
            case 2: return new Vector2(1, -0.9f);
            case 3: return new Vector2(-1, -0.9f);
            default: return new Vector2(0, 0);
        }
    }
}
