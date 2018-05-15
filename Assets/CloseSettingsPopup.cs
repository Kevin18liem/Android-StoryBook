using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseSettingsPopup : MonoBehaviour {

	public GameObject settingsPopup;
	public GameObject navigationButton;
	public GameObject settingsButton;
	public GameObject Grey;
	[SerializeField]
	public void SettingsPopupOff() {
		Grey.SetActive (false);
		settingsPopup.SetActive (false);
		navigationButton.GetComponent<Button> ().interactable = true;
		settingsButton.GetComponent<Button> ().interactable = true;

		Time.timeScale = 1;
		if (PlayerPrefs.GetString ("Narasi") == "on") { 
			GameObject.FindWithTag("subtitle").GetComponent<AudioSource>().UnPause();
		}
	}
}
