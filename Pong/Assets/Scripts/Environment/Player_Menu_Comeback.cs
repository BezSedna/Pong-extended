using UnityEngine;
using UnityEngine.SceneManagement;

// Script responsible for changing scene to main menu when ball touches the trigger in one player game mode

public class Player_Menu_Comeback : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
