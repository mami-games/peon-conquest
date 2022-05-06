using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public void ResetGame() {
        FindObjectOfType<GameDirector>().Reset();
    }
}
