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
		GameObject.Find("Background Music").GetComponent<AudioSource>().UnPause();
		GameObject UI = GameObject.Find ("UI");
		if (UI) {
			UI.SetActive (false);
		}
		if (balikHalaman) {
			balikHalaman.GetComponent<BalikHalaman> ().sceneName = sceneName;
			if (next) {
				balikHalaman.GetComponent<Animator> ().SetTrigger ("balik");
				balikHalaman.GetComponent<AudioSource>().Play ();

			} else {
				balikHalaman.GetComponent<Animator> ().SetTrigger ("balik-sebelum");
				balikHalaman.GetComponent<AudioSource>().Play ();

			}
		} else {
			SceneManager.LoadScene (sceneName);	
		}
	}
}
