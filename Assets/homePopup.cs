using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class homePopup : MonoBehaviour {

	public GameObject homesPopup;
	public GameObject navigationButton;
	public GameObject settingsButton;

	[SerializeField]
	public void HomesPopupOn() {
		homesPopup.SetActive (true);
		navigationButton.GetComponent<Button>().interactable = false;
		settingsButton.GetComponent<Button>().interactable = false;
		Time.timeScale = 0;
	}
}
