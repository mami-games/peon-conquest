using UnityEngine.SceneManagement;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public void GoToTown()
    {
        SceneManager.LoadScene("Town");
    }

    public void GoToBattlefield()
    {
        System.Console.WriteLine("BF clicked");
        SceneManager.LoadScene("Battlefield");
    }
}
