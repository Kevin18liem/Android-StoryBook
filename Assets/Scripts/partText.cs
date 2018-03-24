using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextItemClass;

public class partText : MonoBehaviour {

	TextItem[] stringList;
	Rect startRect;

	// Use this for initialization
	void Start () {
		startRect = new Rect (0,0,100,20);
		stringList = new TextItem[4];
		stringList [0] = new TextItem ("Test ", Color.white);
		stringList [1] = new TextItem ("Test1 ", Color.white);
		stringList [2] = new TextItem ("Test2 ", Color.white);
		stringList [3] = new TextItem ("Test3 ", Color.white);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {
		Rect theRect = startRect;
		//		GUIStyle theStyle = GUI.skin.box;
		GUIStyle theStyle = new GUIStyle();
		theStyle.fontSize = 12;
		theStyle.normal.textColor = Color.red;

		Color oldColor = GUI.color;
		foreach (TextItem thisItem in stringList) {
			//			Debug.Log (thisItem.getText ());
			GUIContent theContent = new GUIContent (thisItem.getText());
			Vector2 theSize = theStyle.CalcSize (theContent);
			GUI.color = thisItem.getColor();
			theRect.width = theSize.x;
			GUI.Box (theRect, theContent, theStyle);
			GUI.color = oldColor;
			theRect.x += theSize.x;
		}
		GUI.color = oldColor;
	}
}

