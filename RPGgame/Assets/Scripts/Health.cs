using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public Slider healthbar;
	public float maxHealth = 10f;
	float currentHealth;
	Animator anim;
	string state = "Movement"; //1
	Health health;

	void Start () {
		currentHealth = maxHealth;
		Animator anim = this.GetComponent<Animator> ();
		health = this.GetComponent<Health> ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.H)) {
			health.TakeDamage (0);
		}
	}
	public void TakeDamage(float amount) {
		currentHealth -= amount;

		healthbar.value = currentHealth / maxHealth;
		if (anim) {
			ChangeState ("Hurt");
		}

	}
	void ChangeState(string stateName){
		state = stateName;
		anim.SetTrigger (stateName);

	}
	void ReturnToMovement() {
		ChangeState ("Movement");
	}

}
