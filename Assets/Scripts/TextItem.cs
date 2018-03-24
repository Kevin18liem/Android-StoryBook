using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextItemClass
{
	[System.Serializable]
	public class TextItem {
		public string text;
		public Color color;
		public float delay = 1;

		public TextItem (){
			text = "";
			color = Color.white;
			delay = 1;
		}

		public TextItem (string text, Color color) {
			this.text = text;
			this.color = color;
		}

		public string getText() {
			return text;
		}

		public Color getColor() {
			return color;
		}
	}
}

