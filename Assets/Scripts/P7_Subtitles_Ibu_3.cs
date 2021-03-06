﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextItemClass;

public class P7_Subtitles_Ibu_3 : MonoBehaviour {

	public bool isStart = false;
	public GameObject ibuSprite;
	public GameObject bapaSpritePertama;
	public GameObject bapaSpriteKedua;
	public GameObject currentBapaSprite;
	public GameObject nextAnakSprite;
	public GameObject nextText;
	public TextItem[] texts;		// texts to be displayed
	public float fade_speed = 1;	// fade speed
	public char newline_char = '$';	// char to be detected as newline
	private string text_buffer;		// buffer to save string
	private int wordset;			// which wordset to display
	private int idx;				// which word to style
	private bool waiting;			// true if waiting
	private bool in_anim;			// in fade animation
	private bool wait_input;		// true if waiting for input
	private string highlighted;		// highlighted part
	private CanvasGroup cg;			// canvas group with alpha

	// Use this for initialization
	void Start () {

		// initialization
		cg = gameObject.GetComponent<CanvasGroup> ();

		idx = 0;
		wordset = 0;
		waiting = false;
		in_anim = false;
		wait_input = false;
		cg.alpha = 0;
		cg.interactable = false;

	}

	// Update is called once per frame
	void Update () {
		if (isStart) {
			// play text if not in fade animation and waiting for input and not end of texts
			if (!waiting && !in_anim && !wait_input && wordset < texts.Length) {
				if (idx < texts [wordset].words.Length) {
					StartCoroutine (Spell (texts [wordset].words [idx].delay));
				}
			}
			// when input got, change text if there are still more text to display
			if (wait_input) {
				if ((((Input.touchCount > 0) && (Input.GetTouch (0).phase == TouchPhase.Began)) || Input.GetMouseButtonDown (0))) {
					wait_input = false;
					ChangeText ();
					nextText.GetComponent<Animator> ().SetTrigger ("fadeout");
					GetComponent<Text> ().text = "";
				}
			}
		}
	}

	IEnumerator Spell (float sec) {

		// if beginning new text, go init
		if (idx == 0) {
			InitText ();
		}

		// make sure animation finished playing
		if (!in_anim) {
			waiting = true;
			yield return new WaitForSeconds (sec);

			// Highlight
			if (PlayerPrefs.GetString ("HighlightText") == "on") {
				HighlightText ();
				Debug.Log ("On highlight");
			}

			// increment
			idx++;
			waiting = false;

		}

		// if end of text ask for input
		if (idx == texts[wordset].words.Length) {
			wait_input = true;
			ibuSprite.GetComponent<Animator> ().SetTrigger ("toIdle");
			nextAnakSprite.GetComponent<Animator> ().SetTrigger ("toSenang");
//			bapaSpritePertama.GetComponent<Animator> ().SetTrigger ("toIdle");
//			bapaSpriteKedua.GetComponent<Animator> ().SetTrigger ("toIdle");
//			currentBapaSprite.GetComponent<Animator> ().SetTrigger ("toIdle");
		}
	}

	IEnumerator Fade(bool fadeIn) {
		in_anim = true;
		if (fadeIn) {
			while (cg.alpha < 1) {
				cg.alpha += Time.deltaTime / 2 * fade_speed;
				yield return null;
			}
			cg.interactable = true;
		} else {
			cg.interactable = false;
			while (cg.alpha > 0) {
				cg.alpha -= Time.deltaTime / 2 * fade_speed;
				yield return null;
			}
		}
		in_anim = false;
	}

	void InitText () {
		text_buffer = "";
		for (int i = 0; i < texts[wordset].words.Length; i++) {
			if (i == 0)
				text_buffer = texts[wordset].words [i].text;
			else
				text_buffer = text_buffer + " " + texts[wordset].words [i].text;
		}

		text_buffer = text_buffer.Replace (newline_char, '\n');

		GetComponent<Text> ().text = text_buffer;
		StartCoroutine (Fade (true));
	}

	void ChangeText() {
		idx = 0;
		wordset++;
		StartCoroutine (Fade (false));
	}

	void HighlightText() {
		text_buffer = "";
		for (int i = 0; i < texts [wordset].words.Length; i++) {
			if (idx == i) {
				highlighted = "<color=\"#e67300\">" + texts [wordset].words [i].text + "</color>";
				if (i == 0)
					text_buffer = "<b>" + highlighted + "</b>";
				else
					text_buffer = text_buffer + " <b>" + highlighted + "</b>";
			} else {
				if (i == 0)
					text_buffer = texts [wordset].words [i].text;
				else
					text_buffer = text_buffer + " " + texts [wordset].words [i].text;
			}
		}

		text_buffer = text_buffer.Replace (newline_char, '\n');

		GetComponent<Text> ().text = text_buffer;
	}

}
