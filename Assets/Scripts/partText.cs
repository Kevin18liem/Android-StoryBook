using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextItemClass;

public class partText : MonoBehaviour {

	TextItem[] stringList;
	Rect startRect;

	private bool doing_color;		// true if still on coroutine
	private bool done;				// true if spelling finished
	private string command;			// command to pass to OnGUI
	private int param1;				// int parameter to pass to OnGUI
	private int param2;				// int parameter to pass to OnGUI

	// Use this for initialization
	void Start () {
		stringList = new TextItem[2];
		stringList [0] = new TextItem ("Pada har minggu ", Color.white);
		stringList [1] = new TextItem ("Naik delman kampret ", Color.white);
		//stringList [2] = new TextItem ("Kududuk samping pak kusir yang sedang bekerja", Color.white);
		//stringList [3] = new TextItem ("Mengendarai kuda supaya baik jalannya ", Color.white);

		doing_color = false;
		done = false;
	}

	// Update is called once per frame
	void Update () {

		if (!doing_color && !done) {
			StartCoroutine (DoColor ());
		}
	}

	void OnGUI() {
		Rect theRect = new Rect (Screen.width/2,Screen.height/3,100,20);;
		GUIStyle theStyle = new GUIStyle ();
		theStyle.fontSize = 12;
		switch (command) {
		case "ColorPartText":
			{
				if (param2 == 1) {
					theStyle.normal.textColor = Color.yellow;
				} else {
					theStyle.normal.textColor = Color.red;
				}

				Color oldColor = GUI.color;
				for(int i = 0; i < stringList.Length; i++) {
					if (param1 == i) {
						theStyle.normal.textColor = Color.yellow;
					} else {
						theStyle.normal.textColor = Color.red;
					}

					GUIContent theContent = new GUIContent (stringList[i].getText ());
					Vector2 theSize = theStyle.CalcSize (theContent);
					GUI.color = stringList[i].getColor ();
					theRect.width = theSize.x;
					Debug.Log ("Right "+ theRect.width + " " + theRect.xMin+","+theRect.yMin+" "+theRect.xMax+","+theRect.yMax);
					GUI.Box (theRect, theContent, theStyle);
					GUI.color = oldColor;
					theRect.x += theSize.x;
				}
				GUI.color = oldColor;
				break;
			}
		default: 
			{
				theStyle.normal.textColor = Color.red;

				Color oldColor = GUI.color;
				foreach (TextItem thisItem in stringList) {
					//			Debug.Log (thisItem.getText ());
					GUIContent theContent = new GUIContent (thisItem.getText ());
					Vector2 theSize = theStyle.CalcSize (theContent);
					GUI.color = thisItem.getColor ();
					theRect.width = theSize.x;
					theRect.center = new Vector2(theRect.center.x - theRect.width / 2, theRect.center.y);
					Debug.Log ("center "+theRect.width + " " + theRect.xMin+","+theRect.yMin+" "+theRect.xMax+","+theRect.yMax);
					GUI.Box (theRect, theContent, theStyle);
					GUI.color = oldColor;
					theRect.x += theSize.x;
				}
				GUI.color = oldColor;
				break;
			}
		}
	}

	IEnumerator DoColor() {
		doing_color = true;
		command = "ColorPartText";
		for (int i = 0; i < 4; i++) {
			if (i == 0) {
				param1 = i;
				param2 = 1;
			} else {
				param1 = i-1;
				param2 = 2;
				param1 = i;
				param2 = 1;
			}
			yield return new WaitForSeconds (1f);
		}
		doing_color = false;
		done = true;
		command = "";
	}

}

