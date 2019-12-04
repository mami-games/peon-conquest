using UnityEngine;

public class CharacterStats
{
    public int maxHealth = 100;
    public int currentHealth;

    public int damage;
    public int armor;
    public int moneyWorth;

    public void TakeDamage(int damage) {        
        damage -= armor;
        damage = Mathf.Clamp(damage, 1, int.MaxValue);

        currentHealth -= damage;        
    }
}
