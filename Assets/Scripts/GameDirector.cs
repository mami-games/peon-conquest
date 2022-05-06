using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    private static GameDirector instance;
    public static GameDirector Instance { get { return instance; } }
    public Text levelUI;

    private float spawnTime = 2;
    private float spawnDelay = 4;
    public int upgradeAttackValue = 5;
    public int money = 0;
    public int numberOfUpgrade = 0;
    private int upgradeCost = 50;
    private int level = 1;
    private const double difficultyMultiplier = 1.15;

    void Start() {        
        
        InvokeRepeating("SpawnEnnemy", spawnTime, spawnDelay);
    }

    public void Awake() {
        instance = this;        

        if (PlayerPrefs.HasKey("Money")) {            
            money = PlayerPrefs.GetInt("Money");
            numberOfUpgrade = PlayerPrefs.GetInt("NumberOfUpgrade");
            level = PlayerPrefs.GetInt("Level");
            levelUI.text = "lvl " + level.ToString();
        } else {
            Save();
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            SpawnPeon();
        }
        if (Input.GetKeyDown(KeyCode.N)) {
            SpawnEnnemy();
        }
    }

    public void Reset() {
        money = 0;
        level = 1;
        Debug.Log(money.ToString());
        Save();
        SceneManager.LoadScene("Battlefield");
    }

    public void UpgradeLevel() {
        level++;
    }

    private void SpawnPeon() {
        Instantiate(
                Resources.Load("Prefabs/AlliedPeon"),
                new Vector3(-20f, 1.5f, Random.Range(-7f, 7f)),
                new Quaternion(0, 0, 0, 0)
            );
    }

    public void SpawnEnnemy() {
        Instantiate(
            Resources.Load("Prefabs/EnemyPeon"),
            new Vector3(20f, 1.5f, Random.Range(-7f, 7f)),
            new Quaternion(0, 180, 0, 0)
            );
    }

    public void UpgradeAlliedTroops() {
        if (money >= upgradeCost) {            
            money -= upgradeCost;
            numberOfUpgrade++;
        }
    }    

    public int GetAttackDamageWithUpgrade() {
        return (upgradeAttackValue * numberOfUpgrade);
    }

    public void OnEnemyUnitKilled(int enemyMoney) {
        money += enemyMoney;        
    }

    public void AlliedWallDestroyed() {
        Save();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void EnemyWallDestroyed() {
        UpgradeLevel();
        Save();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Save() {
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("NumberOfUpgrade", numberOfUpgrade);
        PlayerPrefs.SetInt("Level", level);
    }
}
