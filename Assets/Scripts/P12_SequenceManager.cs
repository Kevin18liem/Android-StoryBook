using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P12_SequenceManager : MonoBehaviour {

	public GameObject subtitle;
	public GameObject nextPageButton;
	public bool inSequence;
	public bool imageSaved = false;
	public GameObject notice;

	private bool noticeOn = false;
	private int sequence;
	private bool inCoroutine;

	// Use this for initialization
	void Start () {

		sequence = 0;
		inSequence = false;
		inCoroutine = false;
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

	public void CheckSaved() {
		if (imageSaved) {
			nextPageButton.GetComponent<changePage> ().changeMenuScene ();
		} else {
			if (!noticeOn)
			DisplayNoticeToSave ();
		}
	}

	public void DisplayNoticeToSave() {
		notice.SetActive (true);
		StartCoroutine (Wait (2));
		noticeOn = true;
	}

	IEnumerator Wait(float sec) {
		yield return new WaitForSeconds (sec);
		notice.SetActive (false);
		noticeOn = false;
	}

}
