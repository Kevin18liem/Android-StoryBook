﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ScreenshotPreview : MonoBehaviour {
	[SerializeField]
	GameObject canvas;
	string[] files = null;

	void Start() {
		files = Directory.GetFiles (Application.persistentDataPath + "/" + "screenshot1.png");
		if (files.Length > 0) {
			GetPictureAndShowIt ();
		}
	}

	void GetPictureAndShowIt() {
		string pathToFile = files [0];
		Texture2D texture = GetScreenshotImage (pathToFile);
		Sprite sp = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), new Vector2 (0.5f, 0.5f));
		canvas.GetComponent<Image> ().sprite = sp;
	}

	Texture2D GetScreenshotImage(string filePath) {
		Texture2D texture = null;
		byte[] fileBytes;
		if (File.Exists (filePath)) {
			fileBytes = File.ReadAllBytes (filePath);
			texture = new Texture2D (2, 2, TextureFormat.RGB24, false);
			texture.LoadImage (fileBytes);
		}
		return texture;
	}
}
