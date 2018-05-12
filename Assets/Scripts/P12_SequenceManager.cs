using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P12_SequenceManager : MonoBehaviour {

	public GameObject subtitle;
	public GameObject nextPageButton;
	public bool inSequence;

	private int sequence;
	private bool inCoroutine;

	// Use this for initialization
	void Start () {

		sequence = 0;
		inSequence = false;
		inCoroutine = false;

	}

	// Update is called once per frame
	void Update () {

		if (!inSequence && !inCoroutine) {
			inSequence = true;
			switch (sequence) {
			case 0:
				{	Debug.Log ("starting");
					subtitle.GetComponent<P12_Subtitles> ().DoSub (0);
					sequence++;
					break;
				}
			case 1:
				{
					Debug.Log ("sub1");
					subtitle.GetComponent<P12_Subtitles> ().DoSub (1);
					sequence++;
					break;
				}
			case 3:
				{
					nextPageButton.SetActive (true);
					break;
				}
			default:
				{
					break;
				}
			}
		}

	}

}
