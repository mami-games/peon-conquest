using UnityEngine;
using UnityEngine.UI;

public class MoneyScore : MonoBehaviour
{
    public GameObject[] enemy;
    public int money;
    public Text moneyScore;

    void Start()
    {
        moneyScore = this.GetComponent<Text>();
        money = 0;
        moneyScore.text = money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //if(enemy == null)
        //{
        //    enemyUnitKilled(enemy.GetComponent<PeonAI>().enemyMoney);
        //}
    }


    public void enemyUnitKilled(int enemyMoney)
    {
        Debug.Log("Je me rend");
        money += enemyMoney;
        moneyScore.text = money.ToString();
    }
}
