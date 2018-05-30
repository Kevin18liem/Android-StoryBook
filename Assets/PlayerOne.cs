using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour {

	[SerializeField]
	static bool AudioBegin = false;
	static private PlayerOne instance;
	protected void Awake() {
		if (instance == null) {
			if (PlayerPrefs.GetString ("Musik") == "on") {
				GetComponent<AudioSource> ().Play ();
			}
			DontDestroyOnLoad (gameObject);
			AudioBegin = true;
			instance = this;
		} else {
			Destroy (this);
		}
	}

	void Update() {
		if (gameObject.tag != "PartOne") {
			Destroy (this.gameObject);
		}
	}
}
