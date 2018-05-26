using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3_IbuAnak : MonoBehaviour {

	public bool allowTap = false;

	private GameObject seqManager;
	private Animator anim;
	private AudioSource soundEffectSelimut;
	private float delayedTime = 2.75F;

	// Use this for initialization
	void Start () {

		seqManager = GameObject.Find ("SequenceManager");
		anim = GetComponent<Animator> ();
		soundEffectSelimut = GetComponent<AudioSource> ();
		soundEffectSelimut.PlayDelayed (delayedTime);
	}
	
	// Update is called once per frame
	void Update () {

		if ((Input.touchCount > 0) && (Input.GetTouch (0).phase == TouchPhase.Began) && allowTap) {

			Ray raycast = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			RaycastHit raycastHit;
			if (Physics.Raycast (raycast, out raycastHit)) {
				if (raycastHit.collider.name == gameObject.name) {
					anim.SetTrigger ("gerak");
				}
			}
				
		} else if (Input.GetMouseButtonDown (0) && allowTap) {
			Ray raycast = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast (raycast, out raycastHit)) {
				if (raycastHit.collider.name == gameObject.name) {
					anim.SetTrigger ("gerak");

				}
			}
		}

	}

	public void NotifyAnimDone() {
		seqManager.GetComponent<P3_SequenceManager> ().AnimationDone ();
	}

	public void PlaySelimutSFX() {
		if (!GetComponent<AudioSource> ().isPlaying) {
			if (PlayerPrefs.GetString ("Musik") == "on") {
				GetComponent<AudioSource> ().Play ();
			}
		}
	}

}
