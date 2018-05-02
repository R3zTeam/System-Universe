using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SubtitleGuiManager : MonoBehaviour {
	
		public Text textBox;

		public void clear(){
			textBox.text = string.Empty; 
		}
		public void SetText (string text)
		{
			textBox.text = text;
		}


}