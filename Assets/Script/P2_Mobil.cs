using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_Mobil : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayCarSound() {
		if (PlayerPrefs.GetString ("Musik") == "on") {
			GetComponent<AudioSource> ().Play ();
		}
	}

}
