﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter(Collision collision)
    {
		GameObject other = collision.gameObject;
		Health otherHealth = other.GetComponent<Health> ();

//        Destroy(gameObject);
		if (otherHealth) {
			otherHealth.TakeDamage (2f);
			Destroy (gameObject);
		}
    }
}
