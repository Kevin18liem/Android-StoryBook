using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homePopup : MonoBehaviour {

	public GameObject homesPopup;
	[SerializeField]
	public void HomesPopupOn() {
		homesPopup.SetActive (true);
		Time.timeScale = 0;
	}
}
