using UnityEngine;
using UnityEngine.UI;

public class MoneyScore : MonoBehaviour
{    
    public int money;
    public Text moneyScoreUI;

    void Start() {
        moneyScoreUI = this.GetComponent<Text>();
        money = 50;
        moneyScoreUI.text = money.ToString();
    }

    public void enemyUnitKilled(int enemyMoney) {
        money = int.Parse(moneyScoreUI.text) + enemyMoney;        
        moneyScoreUI.text = money.ToString();
    }
}
