using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextItemClass;

public class Subtitles : MonoBehaviour {

	public TextItem[] words;		// words to be displayed

	private string text_buffer;		// buffer to save string
	private int idx;				// which word to style
	private bool waiting;			// true if waiting

	// Use this for initialization
	void Start () {

		// initialization

		text_buffer = "";
		for (int i = 0; i < words.Length; i++) {
			if (i == 0)
				text_buffer = words [i].text;
			else
				text_buffer = text_buffer + " " + words [i].text;
		}

		GetComponent<Text> ().text = text_buffer;

		idx = 0;
		waiting = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (!waiting && idx < words.Length) {
			StartCoroutine (Wait (words [idx].delay));
		}

	}

	IEnumerator Wait(float sec) {
		waiting = true;
		yield return new WaitForSeconds(sec);

		text_buffer = "";
		for (int i = 0; i < words.Length; i++) {
			if (idx == i) {
				if (i == 0) 
					text_buffer = "<b>" + words [i].text + "</b>";
				else
					text_buffer = text_buffer + " <b>" + words [i].text + "</b>";
			} else {
				if (i == 0)
					text_buffer = words [i].text;
				else
					text_buffer = text_buffer + " " + words [i].text;
			}
		}
			
		GetComponent<Text> ().text = text_buffer;
		idx++;


		waiting = false;
	}
}
