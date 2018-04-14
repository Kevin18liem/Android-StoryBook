using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltOpacity : MonoBehaviour {
	private float opacityValueFirstFamily;
	private float opacityValueAnotherFamily;
	public GameObject anotherFamily;
	public KeyCode takeOpacityChangeFirstFamily = KeyCode.F;
	public KeyCode takeOpacityChangeAnotherFamily = KeyCode.J;

	private GameObject seqMan;

	public float changeValue;
	void Start () {
		opacityValueFirstFamily = gameObject.GetComponent<SpriteRenderer>().color.r;
		opacityValueAnotherFamily = anotherFamily.GetComponent<SpriteRenderer> ().color.r;
		Input.gyro.enabled = true;
		seqMan = GameObject.Find ("SequenceManager");
	}

	// Update is called once per frame
	void Update () {

		if (seqMan.GetComponent<P6_SequenceManager> ().allowTilt) {
			if (Input.gyro.attitude.x < -0.1f) {
				//Debug.Log (opacityValue);
				Debug.Log (Input.gyro.attitude.x);
				ChangeFirstFamilyOpacity ();

			} 
			if (Input.gyro.attitude.x > 0.18f) {
				ChangeAnotherFamilyOpacity ();
			}

			if (Input.GetKeyDown (takeOpacityChangeFirstFamily)) {
				ChangeFirstFamilyOpacity ();
			}
			if (Input.GetKeyDown (takeOpacityChangeAnotherFamily)) {
				ChangeAnotherFamilyOpacity ();
			}
		}
	}

	void ChangeFirstFamilyOpacity() {
		if (opacityValueAnotherFamily >= 0.2f) {
			opacityValueAnotherFamily -= changeValue;
			if (opacityValueFirstFamily < 1f) {
				opacityValueFirstFamily += changeValue;
			}

			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, opacityValueFirstFamily);
			anotherFamily.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, opacityValueAnotherFamily);
		}
	}

	void ChangeAnotherFamilyOpacity() {
		if (opacityValueFirstFamily >= 0.2f) {
			opacityValueFirstFamily -= changeValue;
			if (opacityValueAnotherFamily < 1f) {
				opacityValueAnotherFamily += changeValue;
			}
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, opacityValueFirstFamily);
			anotherFamily.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, opacityValueAnotherFamily);
		}
	}
}
