using UnityEngine;

public class Menu_Change_Button : MonoBehaviour
{
    [SerializeField] GameObject switched_Menu;

    [SerializeField] GameObject opened_Menu;

    public void Change_Menu()
    {
        opened_Menu.SetActive(true);
        switched_Menu.SetActive(false);
    }
}
