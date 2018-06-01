using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextItemClass;

public class P15_Subtitle : MonoBehaviour {

	public TextItem[] texts;		// texts to be displayed
	public float fade_speed = 3;	// fade speed
	public char newline_char = '$';	// char to be detected as newline
	public GameObject holder;
	//public GameObject sprite;

	private string text_buffer;		// buffer to save string
	private int wordset;			// which wordset to display
	private int idx;				// which word to style
	private bool waiting;			// true if waiting
	private bool in_anim;			// in fade animation
	private string highlighted;		// highlighted part
	private CanvasGroup cg;			// canvas group with alpha
	private IEnumerator speller;
	private GameObject seqManager;
	private bool subAllowed = false;
	public AudioClip audiosub1;
	public AudioClip audiosub2;
	public AudioClip audiosub3;
	private bool waitingForInput;

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
		seqManager = GameObject.Find ("SequenceManager");
		if (!MusicPlayer.seamlessPartFour) {
			MusicPlayer.PlayPartFourMusic ();
			MusicPlayer.seamlessPartFour = true;
			MusicPlayer.seamlessPartOne = false;
			MusicPlayer.seamlessPartTwo = false;
			MusicPlayer.seamlessPartThree = false;
		}
	}

	// Update is called once per frame
	void Update () {

		if (subAllowed) {
			// play text if not in fade animation and waiting for input and not end of texts
			if (!waiting && !in_anim && wordset < texts.Length) {
				if (idx < texts [wordset].words.Length) {
					speller = Spell (texts [wordset].words [idx].delay);
					StartCoroutine (speller);
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.Mouse0) || (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Began)) {
			{
				setToEnd ();
			}
		}

		if (waitingForInput) {
			waitingForInput = false;
			FadeOut ();
		}

	}

	public void DoSub(int _wordset) {
		idx = 0;
		wordset = _wordset;
		subAllowed = true;
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
			subAllowed = false;
			if (wordset == texts.Length - 1) {
				seqManager.GetComponent<P15_SequenceManager> ().inSequence = false;
			} else {
				waitingForInput = true;
			}
			//holder.GetComponent<P15_SubtitleHolder> ().allowClick = true;
			//seqManager.GetComponent<P15_SequenceManager> ().inSequence = false;
			seqManager.GetComponent<P15_SequenceManager> ().sequence++;

			//sprite.GetComponent<Animator> ().SetTrigger ("idle");
		}
	}

	public void FadeOut() {
		StartCoroutine (Fade (false));
	}

	IEnumerator Fade(bool fadeIn) {
		in_anim = true;
		if (fadeIn) {
			while (cg.alpha < 1) {
				cg.alpha += Time.deltaTime / 2 * fade_speed;
				yield return null;
			}
			cg.interactable = true;
			if (PlayerPrefs.GetString ("Narasi") == "on") {
				if (wordset == 0) {
					GetComponent<AudioSource> ().Stop ();
					GetComponent<AudioSource> ().PlayOneShot (audiosub1);
				}
				else if (wordset == 1) {
					GetComponent<AudioSource> ().Stop ();
					GetComponent<AudioSource> ().PlayOneShot (audiosub2);
				} 
				else if (wordset == 2) {
					GetComponent<AudioSource> ().Stop ();
					GetComponent<AudioSource> ().PlayOneShot (audiosub3);
				}
			}	
		} else {
			cg.interactable = false;
			while (cg.alpha > 0) {
				cg.alpha -= Time.deltaTime / 2 * fade_speed;
				yield return null;
			}
			//Debug.Log ("seq set to false");
			seqManager.GetComponent<P15_SequenceManager> ().inSequence = false;
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
		if (wordset != texts.Length - 1) {
			StartCoroutine (Fade (false));
			idx = 0;
			wordset++;
		} else {
			idx = texts[wordset].words.Length;
			HighlightText ();
		}
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

	public void setToEnd() {
		idx = texts [wordset].words.Length - 1;
		Debug.Log ("dipanggil");
	}

}
