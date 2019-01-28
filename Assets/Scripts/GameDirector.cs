using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public GameObject ennemy;
    private float spawnTime = 2;
    private float spawnDelay = 2;

    void Start()
    {
        InvokeRepeating("SpawnEnnemy", spawnTime, spawnDelay);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Instantiate(
                Resources.Load("Prefabs/PeonLeft"), 
                new Vector3(Random.Range(-8f, -5f), 1.69f, Random.Range(-4f, 12f)), 
                new Quaternion(0, 0, 0, 0)
            );
        }
    }

    public void SpawnEnnemy()
    {
        Instantiate(
            Resources.Load("Prefabs/PeonRight"),
            new Vector3(Random.Range(2, 5), 1.69f, Random.Range(-4f, 12f)),
            new Quaternion(0, 180, 0, 0)
            );
    }
}
