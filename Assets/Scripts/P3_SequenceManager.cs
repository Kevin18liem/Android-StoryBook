using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3_SequenceManager : MonoBehaviour {

	public GameObject spriteIbuAnak;
	public GameObject subtitle;
	public GameObject subHolder;
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
				{
					spriteIbuAnak.GetComponent<Animator> ().SetTrigger ("gerak");
					subtitle.GetComponent<P3_Subtitles> ().DoSub (0);

					sequence++;
					break;
				}
			case 1:
				{
					sequence++;
					break;
				}
			case 2:
				{	
					subtitle.GetComponent<P3_Subtitles> ().DoSub (1);
					spriteIbuAnak.GetComponent<P3_IbuAnak> ().allowTap = true;
					sequence++;
					break;
				}
			case 3:
				{
					nextPageButton.SetActive (true);
					nextPageButton.GetComponent<Animator> ().SetTrigger ("glow");
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

}
