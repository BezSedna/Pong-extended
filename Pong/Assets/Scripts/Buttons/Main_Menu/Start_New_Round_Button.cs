using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_New_Round_Button : MonoBehaviour
{
    public void Next_Scene() 
    {
        SceneManager.LoadScene(Game_Mode.game_Mode);
    }
}
