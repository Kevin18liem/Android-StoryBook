using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P5_DelayedAnimationSound : MonoBehaviour {
	private AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource> ();
		audioSource.PlayDelayed (2);
	}

	void Update() {
	}
}