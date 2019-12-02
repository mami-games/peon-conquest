using UnityEngine;

public class EnemyAI : PeonAI
{
    protected override void Start() {
        
        base.Start();
        unitStat.currentHealth = unitStat.maxHealth;
        if (gameObject.name != "WallShortRight") {
            unitStat.damage = 30;
            unitStat.armor = 5;
            unitStat.moneyWorth = 10;
        }
    }

    protected override void Update() {
        if (gameObject.name != "WallShortRight") {
            base.Update();
        }
    }

    public override void Die() {
        if (gameObject.name != "WallShortRight") {
            FindObjectOfType<GameDirector>().OnEnemyUnitKilled(gameObject.GetComponentInParent<PeonAI>().unitStat.moneyWorth);
        } else {
            FindObjectOfType<GameDirector>().EnemyWallDestroyed();
        }
        
        Destroy(gameObject);
    }
}
