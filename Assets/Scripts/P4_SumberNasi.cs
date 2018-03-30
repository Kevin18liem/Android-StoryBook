using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_SumberNasi : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.name == "Sendok") {
			Debug.Log ("enter");
			other.GetComponent<P4_Sendok> ().SetFull();
		}
	}
}
