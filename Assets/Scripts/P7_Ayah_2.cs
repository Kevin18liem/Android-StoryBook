using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextItemClass;

public class P7_Ayah_2 : MonoBehaviour {

	public string trigger;
	public bool isStarting = false;
	public bool startTap = false;
	public bool startNextBapa = false;
	public bool keepMoving = true;
	public GameObject bubbleAnakNext;
	public GameObject nextBapaSprite;
	public GameObject anakNext;
	public GameObject scriptAnakNext;

	// Use this for initialization
	void Start () {
		StartCoroutine (Tunggu ());
	}

	// Update is called once per frame
	void Update () {
		if (startTap) {
			if ((((Input.touchCount > 0) && (Input.GetTouch (0).phase == TouchPhase.Began)) || Input.GetMouseButtonDown (0))) {
				if (!startNextBapa) {
					nextBapaSprite.SetActive (true);
					startNextBapa = true;
				} else {
					GetComponent<Animator> ().SetTrigger ("toGerak");
				}
			}
		}
	}

	IEnumerator Tunggu() {
		yield return new WaitForSeconds (2);
		if (!isStarting) {
			anakNext.GetComponent<Animator> ().SetTrigger ("toNgomong");
			//scriptAnakNext.GetComponent<P7_Subtitles_Anak> ().isStart = true;
			bubbleAnakNext.SetActive (true);
			isStarting = true;
		}
	}
}
