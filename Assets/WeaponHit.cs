﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHit : MonoBehaviour
{
    void Start() {

    }

    void Update() {
        
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Peon") {
            collision.gameObject.GetComponentInChildren<Animator>().SetTrigger("isHit");
        }
    }
}
