using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P8_SequenceManager : MonoBehaviour {

	public GameObject subHolder;
	public GameObject subtitle;
	public GameObject anakSprite;
	public GameObject ibuSprite;
	public GameObject telepon;
	public GameObject videocall;
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
			case 0: // anak ngomong, play subtitle 1
				{
					subtitle.GetComponent<P8_Subtitle> ().DoSub (0);
					break;
				}
			case 1: // ibu gerak, muncul tombol
				{
					ibuSprite.GetComponent<Animator> ().SetTrigger ("gerak");
					videocall.GetComponent<Animator> ().SetTrigger ("muncul");
					videocall.GetComponent<P8_ClickableBaloon> ().allowClick = true;
					StartCoroutine (WaitForTelepon ());
					break;
				}
			default:
				{
					break;
				}
			}
		}

	}

	IEnumerator WaitForTelepon() {
		yield return new WaitForSeconds (1);
		telepon.GetComponent<Animator> ().SetTrigger ("muncul");
		telepon.GetComponent<P8_ClickableBaloon> ().allowClick = true;
	}

}
