﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliedAI : MonoBehaviour
{
    private Animator animator;
    public Transform playerTransform;
    public bool isWalking;    
    public bool isAttacking;
    private GameObject target;
    private GameObject player;
    private float speed;
    public float x;
    public int health;
    public int attackDamage;

    private GameObject closestEnemy = null;        

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        player = GameObject.Find("PeonLeft");
        playerTransform = GetComponent<Transform>();        
        target = null;
        isWalking = false;        
        isAttacking = false;        
        speed = 2f;
        health = 6;
        attackDamage = 1;                
    }

    void Update()
    {
        Debug.Log(closestEnemy);
        if(closestEnemy == null)
        {
            isAttacking = false;
        }
        if (isAttacking != true)
        {
            isWalking = true;
            animator.SetBool("isWalking", isWalking);
            SeekClosestEnemy();                   
        }
        else
        {
            animator.SetBool("isAttacking", isAttacking);
        }        
        ManageAnimation();
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "EnnemyUnit")
        {
            isAttacking = true;
            isWalking = false;            
        }
        if (collision.gameObject.tag == "EnnemyWeapon")
        {
            GameObject ennemy = GameObject.FindGameObjectWithTag(collision.gameObject.tag);
            health -= ennemy.gameObject.GetComponentInParent<EnnemyAI>().attackDamage;

            if (health <= 0)
            {
                Destroy(gameObject);                
            }


        }

    }

    private void ManageAnimation()
    {

        animator.SetBool("isAttacking", isAttacking);
        animator.SetBool("isWalking", isWalking);
    }

    private void SeekClosestEnemy()
    {
        
        closestEnemy = FindClosestEnemy();
        

        if (closestEnemy != null)
        {
            Debug.Log(closestEnemy);
            transform.position = Vector3.MoveTowards(transform.position, closestEnemy.transform.position, speed * Time.deltaTime);            
            isWalking = true;
            isAttacking = false;                        
        }
        Vector3 targetPostition = new Vector3(closestEnemy.transform.position.x,
                                        this.transform.position.y,
                                        closestEnemy.transform.position.z);
        this.transform.LookAt(targetPostition);

    }

    private GameObject FindClosestEnemy()
    {
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnnemyUnit");

        foreach (GameObject enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (enemy != gameObject && enemyDistance < closestDistance)
            {
                closestEnemy = enemy;
                closestDistance = enemyDistance;
            }
        }
        //Debug.Log(closestEnemy);
        return closestEnemy;
    }
}
