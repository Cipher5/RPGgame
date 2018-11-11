using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class rockSpitterController : MonoBehaviour {

	NavMeshAgent nav;
	public GameObject player;
	Vector3 anchor;
	string state;
	Animator anim;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		anchor = transform.position;
		anim = GetComponent<Animator> ();
		state = "Movement";
	}
	
	// Update is called once per frame
	void Update () {
		
		if (state == "Movement") {
			Move ();
		}
		if (state == "Shoot") {
			
		}
	}

	void Move()
	{
		Vector3 target = player.transform.position;
		nav.stoppingDistance = 4f;


		if (Vector3.Distance (transform.position, target) > 7) {
			target = anchor;
			nav.stoppingDistance = 0;
		} else {
//			if (Random.Range(0,100f) < 100f) {
				ChangeState ("Shoot");
//			}
		}
		nav.SetDestination (target);

		anim.SetFloat ("movePercent", nav.velocity.magnitude / nav.speed);
	}
	void ChangeState(string stateName)
	{
		state = stateName;
		anim.SetTrigger (stateName);
	}
	void ReturnToMovement()
	{
		ChangeState ("Movement");
	}
}
