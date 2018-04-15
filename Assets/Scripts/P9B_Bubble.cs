using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P9B_Bubble: MonoBehaviour {

	public Animator anim;				// object's animator
	public bool allowFadeOut = false;	// true if trigger allowed
	public float speed = 1;				// animation speed
	public GameObject subtitle;
	public GameObject sprite;

	// Use this for initialization
	void Start () {

		// initialize animator
		anim = GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update () {

		if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began) && allowFadeOut)
		{
			Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				if (raycastHit.collider.name == gameObject.name)
				{
					anim.SetTrigger("out");
					subtitle.GetComponent<P9B_Subtitles> ().FadeOut ();
					allowFadeOut = false;
				}

			}
		} else if (Input.GetMouseButtonDown(0) && allowFadeOut) {
			Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				if (raycastHit.collider.name == gameObject.name)
				{
					anim.SetTrigger("out");
					subtitle.GetComponent<P9B_Subtitles> ().FadeOut ();
					allowFadeOut = false;
				}

			}
		}

	}
}
