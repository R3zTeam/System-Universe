using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour {

	public GameObject dBox;
	public TampungGambar imageGanti;
	public Text dText;


	public bool dialogActive;
	public Text dcharname;
	public string[] dialogLines;
	public int currentLine;

	// Use this for initialization
	void Start () {
		imageGanti = GetComponent<TampungGambar> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogActive && Input.GetKeyDown (KeyCode.JoystickButton0))
		{
			//dBox.SetActive (false);
			//dialogActive = false;
			currentLine++;
		}

		if (currentLine >= dialogLines.Length) 
		{
			dBox.SetActive (false);
			dialogActive = false;

			currentLine = 0;
		}
		dText.text = dialogLines[currentLine];
		Checkmessage ();
			
	}
	public void ShowBox(string dialogue)
	{
		dialogActive = true;
		dBox.SetActive (true);
		dText.text = dialogue;

	}
	public void ShowDialogue()
	{
		dialogActive = true;
		dBox.SetActive (true);
	}
	void Checkmessage()
	{
		var dialog = dialogLines [currentLine].Split (';');
		if (dialog.Length > 1) 
		{
			var charName = dialog [0];
			var bodyDialog = dialog [1];
		
			dText.text = bodyDialog;
			if(charName == "bacan")
			{
				imageGanti.GambarBacan ();

				bodyDialog = bodyDialog.Replace ("nama", "Bacan");
				dcharname.text = charName;
			}
			else if(charName == "dewi")
			{
				imageGanti.GambarDewi ();
				bodyDialog = bodyDialog.Replace ("nama", "Dewi");
				dcharname.text = charName;
			}
		}

	}

}
