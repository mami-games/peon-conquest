using UnityEngine;
using UnityEngine.UI;

public class UIRefresher : MonoBehaviour
{
    public Text moneyScoreUI;
    public GameDirector gameDirector;

    private void Update() {
        RefreshUI();
    }

    public void RefreshUI() {
        moneyScoreUI.text = gameDirector.money.ToString() + "$";
    }
}
