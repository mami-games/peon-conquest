using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peon : MonoBehaviour
{
    private float movementSpeed = 2f;

    public int hitPoint = 10;
    public int armorPoint = 1;
    public int attackDamage = 6;
    public float attackSpeed = 1f;

    private GameObject closestEnemy = null;
    private Peon target = null;

    void Update() {
        //if (target == null) {
        //    seekClosestEnemy();
        //} else {
        //    attack();
        //}

        if (hitPoint <= 0) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Peon") {
            target = collision.gameObject.GetComponentInParent<Peon>();
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if(target != null) {
            target.takeDamage(attackDamage);
        }
    }

    private void attack() {
        Animator animator = GetComponentInChildren<Animator>();
        animator.speed = attackSpeed;
        animator.SetTrigger("attack");
    }

    private void takeDamage(int damageTaken) {
        int realDamageTaken = damageTaken - armorPoint;

        if(realDamageTaken > 0) {
            hitPoint -= realDamageTaken;
        }
    }

    private void seekClosestEnemy() {
        closestEnemy = findClosestEnemy();

        if (closestEnemy != null) {
            transform.LookAt(closestEnemy.transform);
            transform.position = Vector3.MoveTowards(transform.position, closestEnemy.transform.position, movementSpeed * Time.deltaTime);
        }
    }

    private GameObject findClosestEnemy() {
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Peon");

        foreach (GameObject enemy in enemies) {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (enemy != gameObject && enemyDistance < closestDistance) {
                closestEnemy = enemy;
                closestDistance = enemyDistance;
            }
        }

        return closestEnemy;
    }
}
