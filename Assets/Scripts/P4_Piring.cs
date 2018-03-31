using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_Piring : MonoBehaviour {

	public GameObject nasi;

	// Use this for initialization
	void Start () {
		nasi.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.name == "Sendok") {
			Debug.Log ("enter");
			other.GetComponent<P4_Sendok> ().SetEmpty();
			nasi.SetActive (true);
			nasi.GetComponent<Animator> ().SetTrigger ("isi");

		}
	}

}
