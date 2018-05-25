using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P13_Sparkle : MonoBehaviour {

	public GameObject hint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnableHint() {
		if (!hint.activeSelf) hint.SetActive (true);
	}

}
