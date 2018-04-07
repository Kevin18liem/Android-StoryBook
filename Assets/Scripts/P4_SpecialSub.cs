﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextItemClass;

public class P4_SpecialSub : MonoBehaviour {

	public TextItem[] texts;		// texts to be displayed
	public float fade_speed = 1;	// fade speed
	public char newline_char = '$';	// char to be detected as newline
	public int maxPlateMoved;
	public bool allowText = false;
	public GameObject nextText;

	private string text_buffer;		// buffer to save string
	private int wordset;			// which wordset to display
	private int idx;				// which word to style
	private bool waiting;			// true if waiting
	private bool in_anim;			// in fade animation
	private bool wait_input;		// true if waiting for input
	private string highlighted;		// highlighted part
	private CanvasGroup cg;			// canvas group with alpha
	private bool waitForTap;

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
		waitForTap = false;
	
	}

	// Update is called once per frame
	void Update () {

		if (GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().plateCounter >= maxPlateMoved && allowText) {
			GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().allowPlateMove = false;
		}

		// play text if not in fade animation and waiting for input and not end of texts
		if (!waiting && !in_anim && !wait_input && wordset < texts.Length && allowText &&
			GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().holdNormalSub) {
			if (idx < texts [wordset].words.Length) {
				StartCoroutine (Spell (texts [wordset].words [idx].delay));
			}
		}

		// when input got, change text if there are still more text to display
		if (wait_input && allowText) {
			if (GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().plateCounter >= maxPlateMoved) {
				if (nextText) {
					nextText.GetComponent<P4_SpecialSub> ().allowText = true;
				}
				allowText = false;
				GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().allowPlateMove = true;
				wait_input = false;
				if (gameObject.name == "Ayah") {
					GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().readySpecialToFade = true;
				}
					
			}
					
		}

		if (GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().readySpecialToFade) {
			waitForTap = true;
		}

		if (waitForTap) {
			if ((Input.touchCount > 0) && (Input.GetTouch (0).phase == TouchPhase.Began)) {
				waitForTap = false;
			}
		}

		if (GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().readySpecialToFade && !waitForTap) {
			StartCoroutine (Fade (false));
		}
			

	}

	IEnumerator Spell (float sec) {

		// if beginning new text, go init
		if (idx == 0) {
			InitText ();
			if (gameObject.name == "Ibu") {
				GameObject.Find ("PiringIbu").GetComponent<P4_DraggablePiring> ().putHintHere (GameObject.Find ("PiringIbu").transform.position);
			}
			GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().allowPlateMove = true;
		}

		// make sure animation finished playing
		if (!in_anim) {
			waiting = true;
			yield return new WaitForSeconds (sec);

			// events

			// Highlight
			HighlightText();

			// increment
			idx++;
			waiting = false;

		}

		// if end of text ask for input
		if (idx == texts[wordset].words.Length) {
			wait_input = true;
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
			GameObject.FindGameObjectWithTag ("SequenceManager").GetComponent<P4_SequenceManager> ().holdNormalSub = false;

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