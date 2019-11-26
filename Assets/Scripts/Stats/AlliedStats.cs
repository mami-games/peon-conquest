using UnityEngine;

public class AlliedStats : CharacterStats
{    
    void Start() {
        damage.SetValue(30 + FindObjectOfType<GameDirector>().GetAttackDamageWithUpgrade());
        armor.SetValue(5);
    }

    public override void Die() {
        Destroy(gameObject);
    }
}

