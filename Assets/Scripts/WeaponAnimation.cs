using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{    
    public CharacterStats target;
    public int damage = 5;

    public void OnAttackAnimationHit() {
        target.TakeDamage(gameObject.GetComponentInParent<CharacterStats>().damage.GetValue());
    }
}
