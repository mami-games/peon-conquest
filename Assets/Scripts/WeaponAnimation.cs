using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{            
    public void OnAttackAnimationHit() {
        gameObject.GetComponentInParent<PeonAI>().DealDamageToCurrentTarget();
    }
}
