using UnityEngine;

// Script used in buttons which set difficulty level while playing versus AI

public class Difficulty_Level_Button : MonoBehaviour
{
    [SerializeField] private short difficulty_Level;

    public void OnPressed()
    {
        Difficulty_Level.difficulty_Level = difficulty_Level;
    }
}
