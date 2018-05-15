using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P7_PlaySound : MonoBehaviour {

	bool played;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlaySound() {
		if (!played) {
			if (PlayerPrefs.GetString ("Musik") == "on") {
				GetComponent<AudioSource> ().Play ();
			}
		}
	}

}
