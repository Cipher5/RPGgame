using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeDamage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision collision)
	{
		GameObject other = collision.gameObject;
		Health otherHealth = other.GetComponent<Health> ();

		//        Destroy(gameObject);
		if (otherHealth) {
			otherHealth.TakeDamage (2f);
		}
	}
}
