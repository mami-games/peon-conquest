using UnityEngine;

public class EnemyAI : PeonAI
{
    protected override void Start() {
        base.Start();
        unitStat.currentHealth = unitStat.maxHealth;
        unitStat.damage = 30;
        unitStat.armor = 5;
        unitStat.moneyWorth = 10;        
    }

    protected override void Update() {
        base.Update();
    }

    public override void Die() {
        FindObjectOfType<MoneyScore>().OnEnemyUnitKilled(gameObject.GetComponentInParent<PeonAI>().unitStat.moneyWorth);
        Destroy(gameObject);
    }
}
