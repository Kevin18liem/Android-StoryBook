﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation_Panel_Change_Page : MonoBehaviour {
	public string nextScene;
	public void ToNextPage() {
		SceneManager.LoadScene (nextScene);
		Time.timeScale = 1;
		AudioListener.pause = false;
//		if (PlayerPrefs.GetString ("Musik") == "on") {
//			GetComponent<AudioSource> ().Play ();
//			GameObject.FindWithTag("subtitle").GetComponent<AudioSource>().UnPause();
//		}
	}
}
