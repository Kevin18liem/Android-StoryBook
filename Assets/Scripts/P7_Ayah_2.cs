using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextItemClass;

public class P7_Ayah_2 : MonoBehaviour {

	public string trigger;
	public bool isStarting = false;
	public bool startNextBapa = false;
	public GameObject bapaNext;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		StartCoroutine (Tunggu (true));

	}

	IEnumerator Tunggu(bool wait) {
		if (wait) {
			yield return new WaitForSeconds (3);
		}
		yield return null;
	}
}
