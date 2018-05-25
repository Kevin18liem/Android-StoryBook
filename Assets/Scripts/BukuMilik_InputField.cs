using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BukuMilik_InputField : MonoBehaviour {

	public GameObject nextButton;

	// Use this for initialization
	void Start () {
		Debug.Log (PlayerPrefs.GetString ("PlayerName"));
		if (PlayerPrefs.HasKey("PlayerName")) {
			GetComponent<InputField> ().text = PlayerPrefs.GetString ("PlayerName");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetNextButtonStatus() {
		if (GetComponent<InputField> ().text == "") {
			nextButton.SetActive (false);
		} else {
			nextButton.SetActive (true);
		}
	}

}
