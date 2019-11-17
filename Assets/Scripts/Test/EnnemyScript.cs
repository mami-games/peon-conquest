using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyScript : MonoBehaviour
{

    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            health -= collision.gameObject.GetComponentInParent<LookAtY>().attackDamage;
            Debug.Log(health);
            if(health <= 0)
            {
                Destroy(this);
            }

        }
    }


    private void OnCollisionExit(Collision collision)
    {
    }

    /*private void SeekClosestEnemy()
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
    }*/
}
