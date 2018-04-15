using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextItemClass;

public class P7_Ayah_2 : MonoBehaviour {

	public string trigger;
	public bool isStarting = false;
	public bool startNextBapa = false;
	public GameObject bubbleAnakNext;
	public GameObject anakNext;
	public GameObject scriptAnakNext;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		StartCoroutine (Tunggu ());
	}

	IEnumerator Tunggu() {
		yield return new WaitForSeconds (3);
		if (!isStarting) {
			anakNext.GetComponent<Animator> ().SetTrigger ("toNgomong");
			scriptAnakNext.GetComponent<P7_Subtitles_Anak> ().isStart = true;
			bubbleAnakNext.SetActive (true);
			isStarting = true;
		}
	}
}
