using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextItemClass;

public class P7_SequenceManager : MonoBehaviour {

	public GameObject subtitle;
	public GameObject subtitleIbu;
	public GameObject nextPageBtn;
	public bool inSequence;
	public int sequence;

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
				{
					subtitle.GetComponent<P7_Subtitles_Anak> ().DoSub (0);
					break;
				}
			case 2:
				{
					Debug.Log ("Test Case 2");
					subtitleIbu.GetComponent<P7_Subtitles_Ibu_1> ().DoSub (0);
					break;
				}
			default:
				{
					break;
				}
			}
		}

	}

	public void AnimationDone() {
		inSequence = false;
	}

	public void GlowButton() {
		nextPageBtn.GetComponent<Animator> ().SetTrigger ("glow");
	}

}
