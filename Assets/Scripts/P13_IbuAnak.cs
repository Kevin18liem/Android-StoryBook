using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P13_IbuAnak : MonoBehaviour {

	private GameObject seqManager;

	// Use this for initialization
	void Start () {
		seqManager = GameObject.Find ("SequenceManager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartNgomong() {
		seqManager.GetComponent<P13_SequenceManager> ().inSequence = false;
	}
}
