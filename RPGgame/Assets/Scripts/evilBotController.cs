using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class evilBotController : MonoBehaviour {

	NavMeshAgent nav;
	public GameObject player;
	Vector3 anchor;
	Animator anim;
	string state;


	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		anchor= transform.position;
		state = "Movement";
	}
	
	// Update is called once per frame
	void Update () {
		if (state == "Movement") {
			Move ();
		}
		if (state == "Swing") {
		
		}
	}

	void Move() {
	
		Vector3 target = player.transform.position;
		nav.stoppingDistance = 2f;

		if (Vector3.Distance (transform.position, target) > 10) {
			target = anchor;
			nav.stoppingDistance = 0;
		} else {
			//if (Random.Range (0, 100f) < 2f) {
				//ChangeState ("Swing");
			//}
			if (Vector3.Distance (transform.position,target) < 2) {
				ChangeState ("Swing");
			}
		}


		nav.SetDestination (target);
		anim.SetFloat ("movePercent", nav.velocity.magnitude / nav.speed);
	}
	void ChangeState(string stateName)
	{
		state = stateName;
		anim.SetTrigger (stateName);
	}
	void ReturnToMovement(){
		ChangeState ("Movement");
	}
}
