using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P5_Anak : MonoBehaviour {

	public float animSpeed = 2;

	// Use this for initialization
	void Start () {

		GetComponent<Animator> ().speed = animSpeed;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TriggerAnimation(GameObject toy) {
		GetComponent<Animator> ().SetTrigger (toy.name);
	}

}
