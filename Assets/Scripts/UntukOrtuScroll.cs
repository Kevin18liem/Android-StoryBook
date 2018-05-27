using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UntukOrtuScroll : MonoBehaviour {

	public GameObject topFade;
	public GameObject bottomFade;

	private Scrollbar scroll;

	// Use this for initialization
	void Start () {

		topFade.SetActive (false);
		bottomFade.SetActive (false);
		scroll = GetComponent<Scrollbar>();
	}
	
	// Update is called once per frame
	void Update () {

		if (scroll.value >= 0.9F) {
			topFade.SetActive (false);
		} else {
			if (!topFade.activeSelf) {
				topFade.SetActive (true);
			}
		}

		if (scroll.value == 0) {
			bottomFade.SetActive (false);
		} else {
			if (!bottomFade.activeSelf) {
				bottomFade.SetActive (true);
			}
		}

	}



}
