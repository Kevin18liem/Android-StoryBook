using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextItemClass
{
	[System.Serializable]
	public class WordItem {
		public string text;
		public float delay;

		public WordItem (){
			text = "";
			delay = 1;
		}
			
	}

	[System.Serializable]
	public class TextItem  {
		public WordItem[] words;

		public TextItem() {
		}

	}
}

