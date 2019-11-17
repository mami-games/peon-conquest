using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtY : MonoBehaviour
{
    
    private GameObject closestEnemy = null;
    private float speed;
    private Animator animator;
    private bool ennemyEncountered;
    public int attackDamage;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        speed = 2f;
        ennemyEncountered = false;
        attackDamage = 1;
        SeekClosestEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if(ennemyEncountered == false)
        {
            SeekClosestEnemy();
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnnemyUnit")
        {           
            ennemyEncountered = true;
            animator.SetBool("ennemyEncountered", ennemyEncountered);
        }
    }


    private void OnCollisionExit(Collision collision)
    {        
        ennemyEncountered = false;
        animator.SetBool("ennemyEncountered", ennemyEncountered);
    }

    private void SeekClosestEnemy()
    {

        closestEnemy = FindClosestEnemy();


        if (closestEnemy != null)
        {            
            transform.position = Vector3.MoveTowards(transform.position, closestEnemy.transform.position, speed * Time.deltaTime);
        }
        Vector3 targetPostition = new Vector3(closestEnemy.transform.position.x,
                                        transform.position.y,
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
        return closestEnemy;
    }
}
