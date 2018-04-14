using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P6_SequenceManager : MonoBehaviour {

	public bool allowTilt = false;
	public GameObject button;

	// Use this for initialization
	void Start () {

		button.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void enableButton() {
		button.SetActive (true);
	}

}
