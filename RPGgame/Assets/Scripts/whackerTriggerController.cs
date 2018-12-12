using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whackerTriggerController : MonoBehaviour {

	public GameObject whacker;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider collider)
	{
		GameObject other = collider.gameObject;
		Health otherHealth = other.GetComponent<Health> ();

		if (otherHealth) {
			whacker.gameObject.SetActive (true);
		}
	}
}
