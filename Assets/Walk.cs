using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    private Animator animator;
    private Transform transform;
    public int walkingDirection;
    public float walkingSpeed;
    public bool isAttacking;

    private void Start() {
        animator = GetComponent<Animator>();
        transform = GetComponentInParent<Transform>();
        walkingDirection = 0;
        walkingSpeed = 0.015f;
        isAttacking = false;
    }

    private void Update() {
        ManageInput();
        ManageAnimation();
        WalkPeon();
    }

    private void ManageInput() {
        walkingDirection = 0;
        isAttacking = false;

        if (Input.GetKey(KeyCode.D)) {
            walkingDirection = 1;
        }

        if(Input.GetKey(KeyCode.A)) {
            walkingDirection = -1;
        }

        if (Input.GetKey(KeyCode.Space)) {
            isAttacking = true;
        }
    }

    private void ManageAnimation() {
        animator.SetFloat("walkingDirection", walkingDirection);
        animator.SetBool("isAttacking", isAttacking);
    }

    private void WalkPeon() {
        if(walkingDirection != 0) {
            transform.position = new Vector3(
                transform.position.x + (walkingSpeed * walkingDirection), 
                transform.position.y, 
                transform.position.z
            );
        }
    }
}
