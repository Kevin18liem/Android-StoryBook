using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TextItemClass;

public class P7_Ayah_Script_2 : MonoBehaviour {

	public string trigger;
	public bool isStarting = false;
	public GameObject bapaNextTiga;
	public GameObject anakKaget;
	public GameObject ibuNgomong;
	public GameObject subtitleIbu;

	private bool isFirst = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if ((((Input.touchCount > 0) && (Input.GetTouch (0).phase == TouchPhase.Began)) || Input.GetMouseButtonDown (0))) {
			GetComponent<Animator>().SetTrigger ("toIdle");
			bapaNextTiga.SetActive (true);
			anakKaget.GetComponent<Animator> ().SetTrigger ("toKaget");
			ibuNgomong.GetComponent<Animator> ().SetTrigger ("toNgomong");
			if (!isFirst) {
				subtitleIbu.GetComponent<P7_Subtitles_Ibu_1> ().DoSub (0);
				isFirst = true;
			}
//			GameObject.Find ("SequenceManager").GetComponent<P7_SequenceManager>().sequence += 1;
//			Debug.Log ("test" + GameObject.Find ("SequenceManager").GetComponent<P7_SequenceManager> ().sequence);
		}
	}
}
