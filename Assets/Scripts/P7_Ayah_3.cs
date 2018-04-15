using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextItemClass;

public class P7_Ayah_3 : MonoBehaviour {

	public string trigger;
	public bool isStarting = false;
	public bool startTap = false;
	public bool startNextBapa = false;
	public bool keepMoving = true;
	public GameObject bubbleIbuNext;
	public GameObject ibuNext;
	public GameObject scriptIbuNext;
	public GameObject nextAnakSprite;

	// Use this for initialization
	void Start () {
		StartCoroutine (Tunggu ());
	}

	// Update is called once per frame
	void Update () {
		if (startTap) {
			if ((((Input.touchCount > 0) && (Input.GetTouch (0).phase == TouchPhase.Began)) || Input.GetMouseButtonDown (0))) {
				GetComponent<Animator> ().SetTrigger ("toGerak");
			}
		}
	}

	IEnumerator Tunggu() {
		yield return new WaitForSeconds (2);
		if (!isStarting) {
			ibuNext.GetComponent<Animator> ().SetTrigger ("toNgomong");
			scriptIbuNext.GetComponent<P7_Subtitles_Ibu_3> ().isStart = true;
			bubbleIbuNext.SetActive (true);
			nextAnakSprite.GetComponent<Animator> ().SetTrigger ("toKaget");
			isStarting = true;
		}
	}
}
