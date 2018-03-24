using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextItemClass
{
	public class TextItem {
		string text;
		Color color;

		public TextItem (){
			text = "";
			color = Color.white;
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

