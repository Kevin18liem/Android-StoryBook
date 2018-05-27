using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavButton : MonoBehaviour {

	public bool toRight;
	public ScrollRect rect;
	public float slideVal = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Scroll() {
		if (toRight) {
			rect.horizontalNormalizedPosition += slideVal;
		} else {
			rect.horizontalNormalizedPosition -= slideVal;
		}
	}

}
