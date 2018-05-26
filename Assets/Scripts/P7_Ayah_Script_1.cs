using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextItemClass;

public class P7_Ayah_Script_1 : MonoBehaviour {

	public string trigger;
	public bool isStarting = false;
	public bool startNextBapa = false;
	public GameObject bapaNextDua;
	public GameObject fingerHint;
	public GameObject nextFingerHint;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (isStarting) {
			if ((((Input.touchCount > 0) && (Input.GetTouch (0).phase == TouchPhase.Began)) || Input.GetMouseButtonDown (0))) {
				fingerHint.SetActive (false);
				GetComponent<Animator>().SetTrigger ("toIdle");
				nextFingerHint.SetActive (true);
				bapaNextDua.SetActive (true);
			}
		}
	}
}
