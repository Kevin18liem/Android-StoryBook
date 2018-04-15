using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P9B_SequenceManager : MonoBehaviour {

	public GameObject bgAyah;
	public GameObject spriteAyah;
	public GameObject balonAyahKecil;
	public GameObject balonAyahBesar;
	public GameObject subtitleAyahKecil;
	public GameObject subtitleAyahBesar;
	public GameObject spriteAnak;
	public GameObject balonAnak;
	public GameObject subtitleAnak;
	public GameObject nextPageButton;
	public bool inSequence;

	private int sequence;
	private bool inCoroutine;

	// Use this for initialization
	void Start () {

		sequence = 0;
		inSequence = false;
		inCoroutine = false;

		Debug.Log ("disabling ayah");
		bgAyah.SetActive (false);
		spriteAyah.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (!inSequence && !inCoroutine) {
			inSequence = true;
			switch (sequence) {
			case 0:
				{
					Debug.Log ("seq 0 : delaying");
					StartCoroutine (Delay (1));
					sequence++;
					inSequence = false;
					break;
				}
			case 1:
				{
					Debug.Log ("seq 1 : enabling ayah");
					bgAyah.SetActive (true);
					balonAyahKecil.SetActive (true);
					spriteAyah.SetActive (true);
					spriteAyah.GetComponent<Animator> ().SetTrigger ("ngomong");
					balonAyahKecil.GetComponent<Animator> ().SetTrigger ("in");
					subtitleAyahKecil.GetComponent<P9B_Subtitles> ().DoSub (0);
					sequence++;
					break;
				}
			case 2:
				{
					Debug.Log ("seq 2 : anak reply");
					balonAyahKecil.SetActive (false);
					balonAnak.SetActive (true);
					spriteAnak.GetComponent<Animator> ().SetTrigger ("ngomong");
					balonAnak.GetComponent<Animator> ().SetTrigger ("in");
					subtitleAnak.GetComponent<P9B_Subtitles> ().DoSub (0);
					sequence++;
					break;
				}
			case 3: 
				{
					Debug.Log ("seq 3 : anak reply 2");
					spriteAnak.GetComponent<Animator> ().SetFloat ("mood", 0);
					spriteAnak.GetComponent<Animator> ().SetTrigger ("ngomong");
					balonAnak.GetComponent<Animator> ().SetTrigger ("in");
					subtitleAnak.GetComponent<P9B_Subtitles> ().DoSub (1);
					sequence++;
					break;
				}
			case 4:
				{
					Debug.Log ("seq 4 : ayah reply");
					balonAnak.SetActive (false);
					balonAyahKecil.SetActive (true);
					spriteAyah.GetComponent<Animator> ().SetTrigger ("ngomong");
					balonAyahKecil.GetComponent<Animator> ().SetTrigger ("in");
					subtitleAyahKecil.GetComponent<P9B_Subtitles> ().DoSub (1);
					sequence++;
					break;
				}
			case 5:
				{
					Debug.Log ("seq 5 : ayah reply 2");
					balonAyahKecil.SetActive (false);
					balonAyahBesar.SetActive (true);
					spriteAyah.GetComponent<Animator> ().SetTrigger ("ngomong");
					balonAyahBesar.GetComponent<Animator> ().SetTrigger ("in");
					subtitleAyahBesar.GetComponent<P9B_Subtitles> ().DoSub (0);
					sequence++;
					break;
				}
			case 6:
				{
					Debug.Log ("seq 6 : ayah reply 3");
					spriteAyah.GetComponent<Animator> ().SetTrigger ("ngomong");
					balonAyahBesar.GetComponent<Animator> ().SetTrigger ("in");
					subtitleAyahBesar.GetComponent<P9B_Subtitles> ().DoSub (1);
					sequence++;
					break;
				}
			case 7:
				{
					Debug.Log ("seq 7 : anak reply 3");
					balonAyahBesar.SetActive (false);
					balonAnak.SetActive (true);
					spriteAnak.GetComponent<Animator> ().SetFloat ("mood", 1);
					spriteAnak.GetComponent<Animator> ().SetTrigger ("ngomong");
					balonAnak.GetComponent<Animator> ().SetTrigger ("in");
					subtitleAnak.GetComponent<P9B_Subtitles> ().DoSub (2);
					sequence++;
					break;
				}
			case 8:
				{
					Debug.Log ("seq 8 : ayah reply 4");
					balonAnak.SetActive (false);
					balonAyahKecil.SetActive (true);
					spriteAyah.GetComponent<Animator> ().SetTrigger ("ngomong");
					balonAyahKecil.GetComponent<Animator> ().SetTrigger ("in");
					subtitleAyahKecil.GetComponent<P9B_Subtitles> ().DoSub (2);
					sequence++;
					break;
				}
			case 9:
				{
					Debug.Log ("seq 9 : anak reply 4");
					balonAyahKecil.SetActive (false);
					balonAnak.SetActive (true);
					spriteAnak.GetComponent<Animator> ().SetFloat ("mood", 1);
					spriteAnak.GetComponent<Animator> ().SetTrigger ("ngomong");
					balonAnak.GetComponent<Animator> ().SetTrigger ("in");
					subtitleAnak.GetComponent<P9B_Subtitles> ().DoSub (3);
					sequence++;
					break;
				}
			case 10:
				{
					balonAnak.SetActive (false);
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

	IEnumerator Delay(float sec) {
		inCoroutine = true;
		yield return new WaitForSeconds (sec);
		inCoroutine = false;
	}

}
