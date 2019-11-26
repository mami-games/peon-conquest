using UnityEngine;

public class EnemyStats : CharacterStats
{
    void Start() {
        damage.SetValue(30);
        armor.SetValue(5);
        enemyWorth.SetValue(10);
    }

    public override void Die() {
        FindObjectOfType<MoneyScore>().OnEnemyUnitKilled(enemyWorth.GetValue());
        Destroy(gameObject);
    }
}
