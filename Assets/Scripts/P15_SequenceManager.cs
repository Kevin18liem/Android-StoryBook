using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P15_SequenceManager : MonoBehaviour {

	public GameObject subHolder;
	public GameObject subtitle;
	public GameObject keluargaSprite;
	public GameObject mobilSprite;
	public bool inSequence;
	public GameObject pinchHint;
	public int sequence;
	private bool inCoroutine;

	public GameObject buttonHint;
	// Use this for initialization
	void Start () {
		sequence = 0;
		inSequence = false;
		inCoroutine = false;
		PlayerPrefs.SetString ("HighlightText", "on");
		PlayerPrefs.SetString ("Narasi", "on");
		PlayerPrefs.SetString ("Musik", "on");
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (inSequence + " " + sequence);
		if (!inSequence && !inCoroutine) {
			inSequence = true;
			switch (sequence) {
			case 0: // idle, play subtitle 1
				{
					subtitle.GetComponent<P15_Subtitle> ().DoSub (0);
					break;
				}
			case 1: // idle, play subtitle 2
				{
					subtitle.GetComponent<P15_Subtitle> ().DoSub (1);
					break;
				}
			case 2: // wait for pinch
				{	
					Debug.Log ("waiting for pinch");
					pinchHint.SetActive (true);
					keluargaSprite.GetComponent<P15_Keluarga> ().allowPinch = true;
					break;
				}
			case 3: // ayah masuk mobil
				{
					Debug.Log ("ayah masuk mobil");
					mobilSprite.GetComponent<Animator> ().SetTrigger ("dadah");
					subtitle.GetComponent<P15_Subtitle> ().DoSub (2);
					break;
				}
			case 4: // mobil jalan
				{
					buttonHint.SetActive (true);
					mobilSprite.GetComponent<P15_Mobil> ().allowClick = true;
					break;
				}
			default:
				{
					break;
				}
			}
		}

	}

	public void FinishPinch() {
		inSequence = false;
		sequence++;
	}

}
