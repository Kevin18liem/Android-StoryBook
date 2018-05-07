﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P13_SequenceManager : MonoBehaviour {

	public GameObject spriteAyah;
	public GameObject spritePintu;
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
					spriteAyah.GetComponent<P13_Pintu> ().allowTap = true;
					sequence++;
					break;
				}
			case 1:
				{
					subtitle.GetComponent<P13_Subtitles> ().DoSub (0);
					sequence++;
					break;
				}
			case 2:
				{
					subtitle.GetComponent<P13_Subtitles> ().DoSub (1);
					spriteAyah.GetComponent<Animator> ().SetTrigger ("ngomong");
					sequence++;
					break;
				}
			case 3:
				{
					spriteAyah.GetComponent<Animator> ().SetTrigger ("idle");
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

	public void AyahMasukDone() {
		spritePintu.SetActive (true);
	}

	public void DoorTapped() {
		spriteIbuAnak.GetComponent<Animator> ().SetTrigger ("gerak");
	}

	public void IbuAnakDoneSpell() {
		spriteIbuAnak.GetComponent<Animator> ().SetTrigger ("idle2");
	}

}