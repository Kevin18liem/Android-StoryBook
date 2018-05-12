using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSettingsPopup : MonoBehaviour {
	public GameObject settingsPopup;
	[SerializeField]
	public void SettingsPopupOff() {
		settingsPopup.SetActive (false);
		Time.timeScale = 1;
		if (PlayerPrefs.GetString ("Narasi") == "on") { 
			AudioListener.pause = false;
		}
	}
}
