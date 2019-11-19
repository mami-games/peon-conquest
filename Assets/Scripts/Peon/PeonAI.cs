using System;
using UnityEngine;

public class PeonAI : MonoBehaviour
{
    public GameObject currentTarget;
    public float mouvementSpeed = 3f;
    public int health = 100;
    public int armor = 35;
    private float actionZoneRadius = 1.5f;
    public string enemyTag;
    private int enemyWorth = 10;

    void Update() {
        if (currentTarget != null) {
            LookAtCurrentTarget();
            MoveTowardsCurrentTarget();
        } else {
            currentTarget = FindClosestEnemy();
            GetComponentInChildren<WeaponAnimation>().target = currentTarget ? currentTarget.GetComponent<PeonAI>() : null;
        }

        GetComponentInChildren<Animator>().SetBool("isAttacking", currentTarget != null && CurrentTargetIsReached());
    }

    private GameObject FindClosestEnemy() {
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
        transform.LookAt(currentTarget.transform);
    }

    public void TakeDamage(int damage) {
        health -= (armor < damage) ? (damage - armor) : 1;

        if(health <= 0) {
            if (gameObject.tag == "EnemyPeon")
            {
                FindObjectOfType<MoneyScore>().enemyUnitKilled(enemyWorth);
            }
            Destroy(gameObject);
        }
    }

    private void MoveTowardsCurrentTarget() {
        if(!CurrentTargetIsReached()) {
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
}
