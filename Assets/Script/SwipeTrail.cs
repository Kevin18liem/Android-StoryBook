using UnityEngine;
using System.Collections;
public class SwipeTrail : MonoBehaviour {
	public GameObject trailPrefab;
	GameObject thisTrail;
	Vector3 startPos;
	Plane objPlane;
	public string KodeWarna;
	private void Start() {
		objPlane = new Plane(Camera.main.transform.forward*-1,this.transform.position);
		KodeWarna = "black";
	}
	private void Update() {
		if(((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)|| Input.GetMouseButtonDown(0))) {
			Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			float rayDistance;
			if(objPlane.Raycast(mRay, out rayDistance))
				startPos = mRay.GetPoint(rayDistance);
			thisTrail = (GameObject) Instantiate(trailPrefab,startPos,Quaternion.identity);
				UpdateColor ();
			Debug.Log(thisTrail.transform.position);
		} else if(((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)|| Input.GetMouseButton(0))) {
			Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			float rayDistance;
			if(objPlane.Raycast(mRay,out rayDistance))
				thisTrail.transform.position = mRay.GetPoint(rayDistance);
		}
	}

	private void UpdateColor() {
		if (KodeWarna == "black") {
			thisTrail.GetComponent<TrailRenderer> ().startColor = Color.black;
			thisTrail.GetComponent<TrailRenderer> ().endColor = Color.black;
		} else if (KodeWarna == "red") {
			thisTrail.GetComponent<TrailRenderer> ().startColor = Color.red;
			thisTrail.GetComponent<TrailRenderer> ().endColor = Color.red;
		} else if (KodeWarna == "green") {
			thisTrail.GetComponent<TrailRenderer> ().startColor = Color.green;
			thisTrail.GetComponent<TrailRenderer> ().endColor = Color.green;
		} else if (KodeWarna == "yellow") {
			thisTrail.GetComponent<TrailRenderer> ().startColor = Color.yellow;
			thisTrail.GetComponent<TrailRenderer> ().endColor = Color.yellow;
		} else if (KodeWarna == "blue") {
			thisTrail.GetComponent<TrailRenderer> ().startColor = Color.blue;
			thisTrail.GetComponent<TrailRenderer> ().endColor = Color.blue;
		} else if (KodeWarna == "gray") {
			thisTrail.GetComponent<TrailRenderer> ().startColor = Color.gray;
			thisTrail.GetComponent<TrailRenderer> ().endColor = Color.gray;
		} else if (KodeWarna == "cyan") {
			thisTrail.GetComponent<TrailRenderer> ().startColor = Color.cyan;
			thisTrail.GetComponent<TrailRenderer> ().endColor = Color.cyan;
		} else if (KodeWarna == "white") {
			thisTrail.GetComponent<TrailRenderer> ().startColor = Color.white;
			thisTrail.GetComponent<TrailRenderer> ().endColor = Color.white;
			thisTrail.GetComponent<TrailRenderer> ().startWidth = 1;
			thisTrail.GetComponent<TrailRenderer> ().endWidth = 1;
		}
	}
}