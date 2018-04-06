using UnityEngine;
using System.Collections;
public class SwipeTrail : MonoBehaviour {
	public GameObject trailPrefab;
	GameObject thisTrail;
	Vector3 startPos;
	Plane objPlane;
	public string KodeWarna;
	private Color warnaTertentu;
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
			warnaTertentu = new Color(0,4,59,247);			
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "light green") {
			warnaTertentu = new Color (0, 67, 206, 198);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "yellow") {
			warnaTertentu = new Color (0, 26, 174, 254);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "dark blue") {
			warnaTertentu = new Color (0, 132, 76, 8);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "coklat") {
			warnaTertentu = new Color (0, 0, 36, 110);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "white") {
			thisTrail.GetComponent<TrailRenderer> ().startColor = Color.white;
			thisTrail.GetComponent<TrailRenderer> ().endColor = Color.white;
			thisTrail.GetComponent<TrailRenderer> ().startWidth = 1;
			thisTrail.GetComponent<TrailRenderer> ().endWidth = 1;
		} else if (KodeWarna == "light blue") {
			warnaTertentu = new Color (0, 231, 197, 114);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "orange") {
			warnaTertentu = new Color (0, 10, 116, 253);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "dark green") {
			warnaTertentu = new Color (0, 28, 118, 77);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "cream") {
			warnaTertentu = new Color (0, 129, 175, 243);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "yellow ochre") {
			warnaTertentu = new Color (0, 67, 155, 216);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "gray") {
			thisTrail.GetComponent<TrailRenderer> ().startColor = Color.gray;
			thisTrail.GetComponent<TrailRenderer> ().endColor = Color.gray;
		}
	}
}