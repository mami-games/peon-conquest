using UnityEngine;

public class AlliedAI : PeonAI
{
    protected override void Start() {
        base.Start();
        unitStat.currentHealth = unitStat.maxHealth;
        if (gameObject.name != "WallShortLeft") {
            unitStat.damage = 30 + FindObjectOfType<GameDirector>().GetAttackDamageWithUpgrade();
            unitStat.armor = 5;
        }
    }

    protected override void Update() {
        if (gameObject.name != "WallShortLeft") {
            base.Update();
        }
    }

    public override void Die() {
        if (gameObject.name == "WallShortLeft") {
            FindObjectOfType<GameDirector>().EnemyWallDestroyed();
        }

        Destroy(gameObject);
    }
}
