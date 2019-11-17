using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    public PeonAI target;
    public int damage = 35;

    public void OnAttackAnimationHit() {
        target.TakeDamage(damage);
    }
}
