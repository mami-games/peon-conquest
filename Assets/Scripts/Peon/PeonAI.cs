using System;
using UnityEngine;

public class PeonAI : MonoBehaviour
{
    public GameObject currentTarget;
    public float mouvementSpeed = 3f;
    public int health = 100;
    public int armor = 35;
    private float actionZoneRadius = 1.5f;

    private void Start() {
        GetComponentInChildren<WeaponAnimation>().target = currentTarget.GetComponent<PeonAI>();
    }

    void Update() {
        if(currentTarget != null) {
            LookAtCurrentTarget();
            MoveTowardsCurrentTarget();
        }

        GetComponentInChildren<Animator>().SetBool("isAttacking", currentTarget != null && CurrentTargetIsReached());
    }

    private void LookAtCurrentTarget() {
        transform.LookAt(currentTarget.transform);
    }

    public void TakeDamage(int damage) {
        health -= (armor < damage) ? (damage - armor) : 1;

        if(health <= 0) {
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
