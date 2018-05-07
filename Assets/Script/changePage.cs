using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changePage : MonoBehaviour {

	public GameObject balikHalaman;

	[SerializeField]
	public string sceneName;
	public void changeMenuScene() {
		if (balikHalaman) {
			Debug.Log ("balikhalaman");
			balikHalaman.GetComponent<BalikHalaman> ().sceneName = sceneName;
			balikHalaman.GetComponent<Animator> ().SetTrigger ("balik");
		} else {
			SceneManager.LoadScene (sceneName);	
		}
	}
}
