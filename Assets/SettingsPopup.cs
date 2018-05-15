using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour {
	public GameObject settingsPopup;
	public GameObject navigationButton;
	public GameObject homeButton;

	[SerializeField]
	public void SettingsPopupOn() {
		settingsPopup.SetActive (true);
		navigationButton.GetComponent<Button> ().interactable = false;
		homeButton.GetComponent<Button> ().interactable = false;
		Time.timeScale = 0;
		AudioListener.pause = true;
	}
}
