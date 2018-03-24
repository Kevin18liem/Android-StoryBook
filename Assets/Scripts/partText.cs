using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextItemClass;

public class partText : MonoBehaviour {

	TextItem[] stringList;
	Rect startRect;

	private bool gui_ready;			// true if gui is ready
	private bool doing_color;		// true if still on coroutine
	private bool done;				// true if spelling finished
	private string command;			// command to pass to OnGUI
	private int param1;				// int parameter to pass to OnGUI
	private int param2;				// int parameter to pass to OnGUI

	// Use this for initialization
	void Start () {
		startRect = new Rect (0,0,100,20);
		stringList = new TextItem[4];
		stringList [0] = new TextItem ("Test ", Color.white);
		stringList [1] = new TextItem ("Test1 ", Color.white);
		stringList [2] = new TextItem ("Test2 ", Color.white);
		stringList [3] = new TextItem ("Test3 ", Color.white);

		gui_ready = false;
		doing_color = false;
		done = false;
	}

	// Update is called once per frame
	void Update () {

		if (!doing_color && !done) {
			Debug.Log ("color");
			StartCoroutine (DoColor ());
		}
	}

	void OnGUI() {
		//if (!gui_ready) {
		//			Debug.Log ("Setting GUI");
		//			Rect theRect = startRect;
		//			//		GUIStyle theStyle = GUI.skin.box;
		//			GUIStyle theStyle = new GUIStyle ();
		//			theStyle.fontSize = 12;
		//			theStyle.normal.textColor = Color.red;
		//
		//			Color oldColor = GUI.color;
		//			foreach (TextItem thisItem in stringList) {
		//				//			Debug.Log (thisItem.getText ());
		//				GUIContent theContent = new GUIContent (thisItem.getText ());
		//				Vector2 theSize = theStyle.CalcSize (theContent);
		//				GUI.color = thisItem.getColor ();
		//				theRect.width = theSize.x;
		//				GUI.Box (theRect, theContent, theStyle);
		//				GUI.color = oldColor;
		//				theRect.x += theSize.x;
		//			}
		//			GUI.color = oldColor;
		//			gui_ready = true;
		//StartCoroutine (DoColor ());
		//} else {
		Debug.Log ("command is " + command);
		switch (command) {
		case "ColorPartText":
			Debug.Log ("Color it");
			{
				Rect theRect = startRect;
				GUIStyle theStyle = new GUIStyle ();
				theStyle.fontSize = 12;
				if (param2 == 1) {
					theStyle.normal.textColor = Color.yellow;
				} else {
					theStyle.normal.textColor = Color.red;
				}

				Color oldColor = GUI.color;
				for(int i = 0; i < stringList.Length; i++) {
					//			Debug.Log (thisItem.getText ());

					if (param1 == i) {
						theStyle.normal.textColor = Color.yellow;
					} else {
						theStyle.normal.textColor = Color.red;
					}

					GUIContent theContent = new GUIContent (stringList[i].getText ());
					Vector2 theSize = theStyle.CalcSize (theContent);
					GUI.color = stringList[i].getColor ();
					theRect.width = theSize.x;
					GUI.Box (theRect, theContent, theStyle);
					GUI.color = oldColor;
					theRect.x += theSize.x;
				}
				GUI.color = oldColor;

				//					Color oldColor = GUI.color;
				//					GUIContent theContent = new GUIContent (stringList [param1].getText ());
				//					Vector2 theSize = theStyle.CalcSize (theContent);
				//					GUI.color = stringList [param1].getColor ();
				//					theRect.width = theSize.x;
				//					GUI.Box (theRect, theContent, theStyle);
				//					GUI.color = oldColor;
				break;
			}
		default: 
			{
				Debug.Log ("def");
				Debug.Log ("Setting GUI");
				Rect theRect = startRect;
				//		GUIStyle theStyle = GUI.skin.box;
				GUIStyle theStyle = new GUIStyle ();
				theStyle.fontSize = 12;
				theStyle.normal.textColor = Color.red;

				Color oldColor = GUI.color;
				foreach (TextItem thisItem in stringList) {
					//			Debug.Log (thisItem.getText ());
					GUIContent theContent = new GUIContent (thisItem.getText ());
					Vector2 theSize = theStyle.CalcSize (theContent);
					GUI.color = thisItem.getColor ();
					theRect.width = theSize.x;
					GUI.Box (theRect, theContent, theStyle);
					GUI.color = oldColor;
					theRect.x += theSize.x;
				}
				GUI.color = oldColor;
				gui_ready = true;
				break;
			}
			//}
		}
	}

	IEnumerator DoColor() {
		Debug.Log (command);
		doing_color = true;
		command = "ColorPartText";
		for (int i = 0; i < 4; i++) {
			if (i == 0) {
				param1 = i;
				param2 = 1;
				Debug.Log ("ready " + command);
				//				ColorPartText (i, 1);
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

