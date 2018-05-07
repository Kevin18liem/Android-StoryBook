using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changePage : MonoBehaviour {

	public bool next = true;
	public GameObject balikHalaman;

	[SerializeField]
	public string sceneName;
	public void changeMenuScene() {
		GameObject UI = GameObject.Find ("UI");
		if (UI) {
			UI.SetActive (false);
		}
		if (balikHalaman) {
			balikHalaman.GetComponent<BalikHalaman> ().sceneName = sceneName;
			if (next) {
				balikHalaman.GetComponent<Animator> ().SetTrigger ("balik");

			} else {
				balikHalaman.GetComponent<Animator> ().SetTrigger ("balik-sebelum");

			}
		} else {
			SceneManager.LoadScene (sceneName);	
		}
	}
}
