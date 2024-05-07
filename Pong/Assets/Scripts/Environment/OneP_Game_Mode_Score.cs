using TMPro;
using UnityEngine;

// Script responsible for increasing player score when ball hits player's paddle in one player game mode

public class One_P_Game_Mode_Score : MonoBehaviour
{
    private int score = 0;

    [SerializeField] private TMP_Text score_TMP;

    [SerializeField] private Start_Of_Game start_Of_Game;

    private void Awake()
    {
        score_TMP.text = "0";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            score++;
            score_TMP.text = score.ToString();
        }
    }
}