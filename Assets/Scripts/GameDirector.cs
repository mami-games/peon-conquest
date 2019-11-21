using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    private float spawnTime = 2;
    private float spawnDelay = 4;
    public int upgradeAttackValue = 5;
    private int numberOfUpgrade = 0;
    private int upgradeCost = 50;

    void Start() {
        InvokeRepeating("SpawnEnnemy", spawnTime, spawnDelay);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            Instantiate(
                Resources.Load("Prefabs/AlliedPeon"),
                new Vector3(-20f, 1.5f, Random.Range(-7f, 7f)),
                new Quaternion(0, 0, 0, 0)
            );
        }
    }

    public void SpawnEnnemy() {
        Instantiate(
            Resources.Load("Prefabs/EnemyPeon"),
            new Vector3(20f, 1.5f, Random.Range(-7f, 7f)),
            new Quaternion(0, 180, 0, 0)
            );
    }

    public void UpgradeAlliedTroops() {
        int money = int.Parse(FindObjectOfType<MoneyScore>().GetComponent<Text>().text);

        if (money >= upgradeCost) {            
            money -= upgradeCost;
            numberOfUpgrade++;
            FindObjectOfType<MoneyScore>().GetComponent<Text>().text = money.ToString();
        } else {
            Debug.Log("Can't upgrade");
        }

        Debug.Log(FindObjectOfType<MoneyScore>().GetComponent<Text>().text);
    }

    public int GetAttackDamageWithUpgrade() {
        return (upgradeAttackValue * numberOfUpgrade);
    }
}
