using System;
using UnityEngine;

public class PeonAI : MonoBehaviour
{
    public GameObject currentTarget;
    public float mouvementSpeed = 3f;
    public CharacterStats unitStat;
    private float actionZoneRadius = 1.5f;
    public string enemyTag;
    

    protected virtual void Start() {
        unitStat = new CharacterStats();
    }

    protected virtual void Update() {
        SeekAndDestroyEnemy();
    }

    public void SeekAndDestroyEnemy() {
        currentTarget = FindClosestEnemy();
        LookAtCurrentTarget();
        MoveTowardsCurrentTarget();
        GetComponentInChildren<Animator>().SetBool("isAttacking", currentTarget != null && CurrentTargetIsReached());
    }

    public GameObject FindClosestEnemy() {
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject enemy in enemies) {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (enemy != gameObject && enemyDistance < closestDistance) {
                closestEnemy = enemy;
                closestDistance = enemyDistance;
            }
        }
        
        return closestEnemy;
    }

    private void LookAtCurrentTarget() {
        if (currentTarget != null) {
            transform.LookAt(currentTarget.transform);
        }
    }

    public void TakeDamage(int damage) {        
        unitStat.TakeDamage(damage);
        if(unitStat.currentHealth <= 0) {
            Die();
        }
    }

    public void DealDamageToCurrentTarget() {        
        currentTarget.GetComponent<PeonAI>().TakeDamage(unitStat.damage);
    }

    private void MoveTowardsCurrentTarget() {
        if (!CurrentTargetIsReached()) {
            transform.position = Vector3.MoveTowards(
                transform.position,
                currentTarget.transform.position,
                GetDeltaMouvementSpeed()
            );
        }
    }

    private bool CurrentTargetIsReached() {
        return GetDistanceFromCurrentTarget() <= actionZoneRadius;
    }

    private float GetDeltaMouvementSpeed() {
        return mouvementSpeed * Time.deltaTime;
    }

    private float GetDistanceFromCurrentTarget() {
        return Vector3.Distance(
            transform.position,
            currentTarget.transform.position
        );
    }

    public virtual void Die() { }
}
