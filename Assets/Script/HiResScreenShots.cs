using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HiResScreenShots : MonoBehaviour {
	public int resWidth; 
	public int resHeight;
	public KeyCode takeScreenshotKey = KeyCode.S;
	public int screenshotCount = 0;
	public GameObject crayon;
	private void Start() {
		
	}
	private void Update() {
		if (Input.GetKeyDown(takeScreenshotKey) || Input.touchCount == 2)
	    {
			crayon.SetActive (false);
	        StartCoroutine(captureScreenshot());
	    }
	}
	IEnumerator captureScreenshot()
	{
	    yield return new WaitForEndOfFrame();
		string path =Application.persistentDataPath+ "/screenshot1.png";

		Texture2D screenImage = new Texture2D(resWidth, resHeight);
	    //Get Image from screen			
		screenImage.ReadPixels(new Rect(60, 43, resWidth, resHeight), 0, 0);
		//screenImage.ReadPixels(new Rect(75, 191, resWidth, resHeight), 0, 0);
		screenImage.Apply();
		crayon.SetActive (true);
	    //Convert to png
	    byte[] imageBytes = screenImage.EncodeToPNG();
	    //Save image to file
	    System.IO.File.WriteAllBytes(path, imageBytes);
	}
	public void TakeSS() {
		crayon.SetActive(false);
		StartCoroutine(captureScreenshot());
	}
}
