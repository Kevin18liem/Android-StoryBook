using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!MusicPlayer.seamlessPartOne) {
			MusicPlayer.PlayPartOneMusic ();
			MusicPlayer.seamlessPartOne = true;
			MusicPlayer.seamlessPartTwo = false;
			MusicPlayer.seamlessPartThree = false;
			MusicPlayer.seamlessPartFour = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
