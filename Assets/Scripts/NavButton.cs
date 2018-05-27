using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavButton : MonoBehaviour {

	public bool toRight;
	public ScrollRect rect;
	public float slideVal = 0.1f;
	public GameObject fadeKanan;
	public GameObject fadeKiri;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (rect.horizontalNormalizedPosition <= 0.05f) {
			fadeKiri.SetActive (false);
		} else {
			fadeKiri.SetActive (true);
		}

		if (rect.horizontalNormalizedPosition >= 0.95f) {
			fadeKanan.SetActive (false);
		} else {
			fadeKanan.SetActive (true);
		}

	}

	public void Scroll() {
		if (toRight) {
			rect.horizontalNormalizedPosition += slideVal;
		} else {
			rect.horizontalNormalizedPosition -= slideVal;
		}
	}

}
