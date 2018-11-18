using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordRagdollController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "ragdollTrigger") {
			Debug.Log ("Splat");
			//transform.Rotate (Vector3.up * Time.deltaTime);
		}
	}
}
