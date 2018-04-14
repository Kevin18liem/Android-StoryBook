using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToWipe : MonoBehaviour {

	public GameObject nextWipe;

	// Use this for initialization
	void Start () {
		InitWipe ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void InitWipe() {
		StartCoroutine (Tunggu(true));
	}

	IEnumerator Tunggu(bool wait) {
		if (wait) {
			yield return new WaitForSeconds (5);
		}
		nextWipe.GetComponent<Wiper>().startWipe = true;
		gameObject.SetActive (false);
		yield return null;
	}
}
