using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class GameDirector : MonoBehaviour
{    
    private float spawnTime = 2;
    private float spawnDelay = 4;

    void Start()
    {
        InvokeRepeating("SpawnEnnemy", spawnTime, spawnDelay);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Instantiate(
                Resources.Load("Prefabs/AlliedPeon"), 
                new Vector3(-20f, 1.5f, Random.Range(-7f, 7f)), 
                new Quaternion(0, 0, 0, 0)
            );
        }
    }

    public void SpawnEnnemy()
    {
        Instantiate(
            Resources.Load("Prefabs/EnemyPeon"),
            new Vector3(20f, 1.5f, Random.Range(-7f, 7f)),
            new Quaternion(0, 180, 0, 0)
            );
    }
}
