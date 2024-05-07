using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script responsible for checkig if ball tauched goal trigger, increasing
// player/ enemy score, playing goal sound and triggering the start of another round 
// (it also change scene to main menu when one of players has 11 points)

public class Goal : MonoBehaviour
{
    private int score = 0;

    [SerializeField] private TMP_Text score_TMP;

    [SerializeField] private AudioSource goal_Sound;

    [SerializeField] private Start_Of_Game start_Of_Game;

    private void Awake()
    {
        score_TMP.text = "0";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            start_Of_Game.Start_New_Round();
            score++;
            if (score >= 11)
            {
                SceneManager.LoadScene(0);
            }
            score_TMP.text = score.ToString();
            goal_Sound.Play();
        }
    }
}
