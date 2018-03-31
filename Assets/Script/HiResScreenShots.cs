using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HiResScreenShots : MonoBehaviour {
	public int resWidth = 4300; 
	public int resHeight = 3300;
	public KeyCode takeScreenshotKey = KeyCode.S;
	public int screenshotCount = 0;

	private void Start() {
	}
	private void Update() {
		if (Input.GetKeyDown(takeScreenshotKey))
	    {
	        StartCoroutine(captureScreenshot());
	    }
	}
	IEnumerator captureScreenshot()
	{
	    yield return new WaitForEndOfFrame();
		string path =Application.persistentDataPath+ "/screenshot1.png";

		Texture2D screenImage = new Texture2D(Screen.width-500, Screen.height-500);
	    //Get Image from screen
	    screenImage.ReadPixels(new Rect(500, 500, Screen.width-500, Screen.height-500), 0, 0);
	    screenImage.Apply();
	    //Convert to png
	    byte[] imageBytes = screenImage.EncodeToPNG();

	    //Save image to file
	    System.IO.File.WriteAllBytes(path, imageBytes);
	}
}