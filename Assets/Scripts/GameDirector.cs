using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Instantiate(
                Resources.Load("Prefabs/PeonLeft"), 
                new Vector3(Random.Range(-8f, -5f), 1.69f, Random.Range(-4f, 12f)), 
                new Quaternion(0, 0, 0, 0)
            );
        }
    }
}
