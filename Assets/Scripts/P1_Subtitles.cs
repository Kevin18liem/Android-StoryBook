using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextItemClass;

public class P1_Subtitles : MonoBehaviour {

	public TextItem[] texts;		// texts to be displayed
	public float fade_speed = 1;	// fade speed
	public char newline_char = '$';	// char to be detected as newline
	public GameObject sprites;		// sprites to be animated

	private string text_buffer;		// buffer to save string
	private int wordset;			// which wordset to display
	private int idx;				// which word to style
	private bool waiting;			// true if waiting
	private bool in_anim;			// in fade animation
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
		cg.alpha = 0;
		cg.interactable = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (!waiting && !in_anim && wordset < texts.Length) {
			if (idx < texts [wordset].words.Length) {
				StartCoroutine (Spell (texts [wordset].words [idx].delay));
			}
		}

	}

	IEnumerator Spell (float sec) {

		if (idx == 0) {
			InitText ();
		}

		if (!in_anim) {
			waiting = true;
			yield return new WaitForSeconds (sec);

			// events
			if (wordset == 0 && idx == 5) {
				sprites.transform.GetChild (5).GetComponent<P1_TriggerAnimation> ().anim.SetTrigger ("menunduk");
			}

			if (wordset == 1 && idx == 0) {
				sprites.transform.GetChild (1).GetComponent<P1_TriggerAnimation> ().anim.SetTrigger ("terkejut");
				sprites.transform.GetChild (4).GetComponent<P1_TriggerAnimation> ().anim.SetTrigger ("ngelus");
			}

			if (wordset == texts.Length - 1 && idx == texts[texts.Length-1].words.Length-1) {
				sprites.transform.GetChild (5).GetComponent<P1_TriggerAnimation> ().trigger_allowed = true;
				sprites.transform.GetChild (4).GetComponent<P1_TriggerAnimation> ().trigger_allowed = true;
			}

			// Highlight
			HighlightText();

			idx++;
			waiting = false;

		}

		if (idx == texts[wordset].words.Length) {
			ChangeText ();
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
