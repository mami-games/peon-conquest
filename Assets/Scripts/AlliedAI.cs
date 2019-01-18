using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliedAI : MonoBehaviour
{
    private Animator animator;
    public Transform playerTransform;
    public int walkingDirection;
    public float walkingSpeed;
    public bool isAttacking;
    private GameObject target;

    public float maxForce = 15;
    public float maxSpeed = 30;
    public float maxVelocity = 200;
    public float mass = 15;

    Vector3 velocity;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerTransform = GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Peon");
        walkingDirection = 1;
        walkingSpeed = 0.115f;
        isAttacking = false;

        velocity = Vector3.zero;
    }

    void Update()
    {
        ManageAnimation();
        SeekTarget();
        //WalkPeon();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PeonRight")
        {

            walkingDirection = 0;
            animator.SetBool("isAttacking", true);


            Debug.Log(animator.GetBool("isAttacking"));
        }

    }

    private void ManageAnimation()
    {
        animator.SetFloat("walkingDirection", walkingDirection);
    }

    private void WalkPeon()
    {
        //if (walkingDirection != 0)
        //{

        transform.LookAt(target.transform);
        transform.position = new Vector3(
                transform.position.x + (walkingSpeed * walkingDirection),
                transform.position.y,
                transform.position.z
            );
        //}
    }

    private void SeekTarget()
    {
        //transform.LookAt(target.transform);

        var desiredVelocity = target.transform.position - transform.position;
        desiredVelocity = desiredVelocity.normalized * maxVelocity * Time.deltaTime;

        var steering = desiredVelocity - velocity;
        steering = Vector3.ClampMagnitude(steering, maxForce);
        steering = steering / mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, maxSpeed);
        transform.position += velocity * Time.deltaTime;
    }
}
