using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxBreakerController : MonoBehaviour {

	public GameObject BrokenBox;
	public bool boxBroken;

	void Start () {
		boxBroken = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerExit (Collider other)

	{

		if (other.gameObject.tag == "hitDetector") {
			if (boxBroken == false) {
				Destroy (this.gameObject);
				boxBroken = true;
				Instantiate (BrokenBox, this.transform.position, this.transform.rotation, null);
			}
		}
		if (other.gameObject.tag == "instaDeath") {
			if (boxBroken == false) {
				Destroy (this.gameObject);
				boxBroken = true;
				Instantiate (BrokenBox, this.transform.position, this.transform.rotation, null);
			}
		}
	}
}
