using UnityEngine;

public class AlliedAI : PeonAI
{
    protected override void Start() {
        base.Start();
        unitStat.currentHealth = unitStat.maxHealth;
        unitStat.damage = 30 + FindObjectOfType<GameDirector>().GetAttackDamageWithUpgrade();
        unitStat.armor = 5;
    }

    protected override void Update() {
        base.Update();
    }

    public override void Die() {
        Destroy(gameObject);
    }
}
