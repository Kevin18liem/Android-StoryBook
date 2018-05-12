using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BukuMilik_nextButton : MonoBehaviour {

	public InputField inputfield;
	public string nextScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ToNextPage() {
		PlayerPrefs.SetString ("PlayerName", inputfield.text);
		SceneManager.LoadScene (nextScene);
	}

}
