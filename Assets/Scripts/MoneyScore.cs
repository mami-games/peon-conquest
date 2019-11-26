using UnityEngine;
using UnityEngine.UI;

public class MoneyScore : MonoBehaviour
{        
    public Text moneyScoreUI;

    void Start() {
        moneyScoreUI = this.GetComponent<Text>();
        moneyScoreUI.text = FindObjectOfType<GameDirector>().money.ToString(); 
    }

    public void OnEnemyUnitKilled(int enemyMoney) {
        int moneyTemp = FindObjectOfType<GameDirector>().money;
        moneyTemp = int.Parse(moneyScoreUI.text) + enemyMoney;        
        moneyScoreUI.text = moneyTemp.ToString();
    }
}
