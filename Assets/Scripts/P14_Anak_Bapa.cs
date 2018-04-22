using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextItemClass;

public class P14_Anak_Bapa : MonoBehaviour {

	public bool isStarting = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (isStarting) {
			if ((((Input.touchCount > 0) && (Input.GetTouch (0).phase == TouchPhase.Began)) || Input.GetMouseButtonDown (0))) {
				GetComponent<Animator> ().SetTrigger ("toGerak");
			}
		}
	}
}
