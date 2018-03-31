using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4_SequenceManager : MonoBehaviour {

	public bool allowPlateMove = false;
	public bool allowClutterAnim = false;
	public bool holdNormalSub = false;
	public bool plateCheck1 = false;
	public bool plateCheck2 = false;
	public bool plateCheck3 = false;
	public int plateCounter = 0;
	public bool readySpecialToFade = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool checkPlate(string objName) {
		switch (objName) {
		case "PiringIbu":
			return plateCheck1;
		case "PiringAnak":
			return plateCheck2;
		case "PiringAyah": 
			return plateCheck3;
		default:
			return false;
		}
	}

	public void setPlate(string objName) {
		switch (objName) {
		case "PiringIbu":
			plateCheck1 = true;
			break;
		case "PiringAnak":
			plateCheck2 = true;
			break;
		case "PiringAyah": 
			plateCheck3 = true;
			break;
		}
	}
}
