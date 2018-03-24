using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour {

	public float linear_limit;			// how long the camera can move (from -limit to limit)
	public float angle_limit = 45;		// max device rotation to linear limit
	public float movement_speed = 1;	// camera move speed
	public GameObject detector;			// rotation detector

	private float pos;					// camera position
	private Vector3 init_pos;			// this object's initial position

	// Use this for initialization
	void Start () {

		// initialization
		init_pos = transform.position;

	}

	// Update is called once per frame
	void Update () {

		detector.transform.Rotate (0, -Input.gyro.rotationRateUnbiased.y, 0);
		Debug.Log (detector.transform.eulerAngles);

		if (detector.transform.eulerAngles.y < 180) {
			pos = init_pos.x + (detector.transform.eulerAngles.y / angle_limit) * linear_limit;
			if (pos > linear_limit) {
				pos = linear_limit;
			}
	
		} else {
			pos = init_pos.x + ((detector.transform.eulerAngles.y - 360) / angle_limit) * linear_limit;
			if (pos < -linear_limit) {
				pos = -linear_limit;
			}
		}
			
		Debug.Log (pos);
		transform.position = Vector3.Lerp (transform.position, 
			new Vector3 (pos, init_pos.y,init_pos.z),
			movement_speed);

	}

}