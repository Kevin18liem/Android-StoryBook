using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour {
	public GameObject settingsPopup;
	[SerializeField]
	public void SettingsPopupOn() {
		settingsPopup.SetActive (true);
		Time.timeScale = 0;
	}
}
