using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public Slider healthbar;
	public float maxHealth;
	float currentHealth;
	Health health;

	void Start () {
		currentHealth = maxHealth;

		health = this.GetComponent<Health> ();
		maxHealth = 10f;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.H)) {
			health.TakeDamage (1f);
		}
	}
	public void TakeDamage(float amount) {
		currentHealth -= amount;

		healthbar.value = currentHealth / maxHealth;
		Animator anim = this.GetComponent<Animator> ();
		if (anim) {
			playerController pc;
			pc = this.GetComponent<playerController>();
			if (pc) {
				pc.ChangeState ("Hurt");
			}
		}

	}

	void ReturnToMovement() {
		 //("Movement");
	}



}
