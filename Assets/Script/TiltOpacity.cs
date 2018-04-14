using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltOpacity : MonoBehaviour {
	private float opacityValueFirstFamily;
	private float opacityValueAnotherFamily;
	private float inputGyroValue;
	public GameObject anotherFamily;
	public KeyCode takeOpacityChange = KeyCode.S;
	public float changeValue;
	void Start () {
		opacityValueFirstFamily = gameObject.GetComponent<SpriteRenderer>().color.r;
		opacityValueAnotherFamily = anotherFamily.GetComponent<SpriteRenderer> ().color.r;
		Input.gyro.enabled = true;
		inputGyroValue = Input.gyro.rotationRate.y;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.gyro.attitude.x < -0.1f) {
			//Debug.Log (opacityValue);
			Debug.Log (Input.gyro.attitude.x);
			if (opacityValueAnotherFamily >= 0.2f) {
				opacityValueFirstFamily += changeValue;
				opacityValueAnotherFamily -= changeValue;
				gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, opacityValueFirstFamily);
				anotherFamily.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, opacityValueAnotherFamily);
			}
		} 
		if (Input.gyro.attitude.x > 0.18f) {
			if (opacityValueFirstFamily >= 0.2f) {
				opacityValueFirstFamily -= changeValue;
				opacityValueAnotherFamily += changeValue;
				gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, opacityValueFirstFamily);
				anotherFamily.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, opacityValueAnotherFamily);
			}
		}
	}
}
