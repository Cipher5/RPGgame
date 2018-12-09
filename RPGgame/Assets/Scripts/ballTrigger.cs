using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballTrigger : MonoBehaviour {

	public GameObject ballHolder;

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
			ballHolder.gameObject.SetActive (false);
		}
	}
}
