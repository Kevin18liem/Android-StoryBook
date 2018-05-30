using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour {
	public GameObject settingsPopup;
	public GameObject navigationButton;
	public GameObject homeButton;
	public GameObject Grey;
	[SerializeField]
	public void SettingsPopupOn() {
		GameObject uiObject = GameObject.Find ("UI");
		if (PlayerPrefs.GetString ("Musik") == "on") {
			uiObject.GetComponent<AudioSource>().Play();
		}
		Grey.SetActive (true);
		settingsPopup.SetActive (true);
		navigationButton.GetComponent<Button> ().interactable = false;
		homeButton.GetComponent<Button> ().interactable = false;
		Time.timeScale = 0;
		//AudioListener.pause = true;
		GameObject.FindWithTag("subtitle").GetComponent<AudioSource>().Pause();
		GameObject.Find("Background Music").GetComponent<AudioSource>().Pause();
	}
}
