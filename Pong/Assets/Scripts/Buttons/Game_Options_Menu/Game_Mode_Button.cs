using UnityEngine;

// Script used in buttons which set game mode 

public class Game_Mode_Button : MonoBehaviour
{
    [SerializeField] private short game_Mode;

    public void OnPressed() 
    {
        Game_Mode.game_Mode = game_Mode;
    }
}
