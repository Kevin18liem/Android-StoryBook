using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class homePopup : MonoBehaviour {

	public GameObject homesPopup;
	public GameObject navigationButton;
	public GameObject settingsButton;
	public GameObject Grey;
	[SerializeField]
	public void HomesPopupOn() {
		GameObject uiObject = GameObject.Find ("UI");
		uiObject.GetComponent<AudioSource>().Play();
		homesPopup.SetActive (true);
		Grey.SetActive (true);
		navigationButton.GetComponent<Button>().interactable = false;
		settingsButton.GetComponent<Button>().interactable = false;
		Time.timeScale = 0;
		//AudioListener.pause = true;
		GameObject.FindWithTag("subtitle").GetComponent<AudioSource>().Pause();
	}
}
