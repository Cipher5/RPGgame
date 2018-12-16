using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserTrigger : MonoBehaviour {

	public GameObject Laser;
	// Use this for initialization
	void Start () {
		Laser.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider collider)
	{
		GameObject other = collider.gameObject;
		Health otherHealth = other.GetComponent<Health> ();

		if (otherHealth) {
			Laser.gameObject.SetActive (true);
		}
	}
}
