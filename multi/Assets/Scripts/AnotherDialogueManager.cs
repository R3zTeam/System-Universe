using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
public class AnotherDialogueManager : MonoBehaviour {
	private AudioClip dialogueAudio;
	public AudioSource audioSurce;
	private string[] fileLines;

	//variable subtittle
	private List<string> subtitleLines = new List<string>();

	private List<string> subtitleTimingString = new List<string>();
	public List<float>  subtitleTimings = new List<float>();

	public List<string> subtitleText = new List<string> ();

	private int nextSubtitle = 0;

	private string displaySubtitle;

	//trigger variable
	private List<string> triggerLines = new List<string>();
	private List<string> triggerTimingString = new List<string>();
	public List<float> triggerTimings = new List<float> ();

	private List<string> triggers = new List<string>();

	public List<string> triggerObjectNames = new List <string> ();

	public List<string> triggerMethodNames = new List<string> ();

	public int nextTrigger = 0;
	 






	public static AnotherDialogueManager Instance { get; private set; }
		


	void Awake()
	{
		if (Instance != null && Instance != this) 
		{
			Destroy (gameObject);
		}
		Instance = this;

		gameObject.AddComponent<AudioSource> ();
	}

	public void BeginDialogue(AudioClip passedClip)
	{
		dialogueAudio = passedClip;

		// reset subtitle
		subtitleLines = new List<string>();
		subtitleTimingString = new List<string> ();
		subtitleTimings = new List<float> ();
		subtitleText = new List<string>();

		triggerLines = new List<string> ();
		triggerTimingString = new List<string> ();
		triggerTimings = new List<float>();
		triggers = new List<string> ();
		triggerObjectNames = new List<string> ();
		triggerMethodNames = new List<string> ();

		nextSubtitle = 0;
		nextTrigger = 0;

		TextAsset temp = Resources.Load("Dialogues/" + dialogueAudio.name) as TextAsset;
		fileLines = temp.text.Split('\n');


		//toSplit in dialogue subttile
		foreach(string line in fileLines){
			if (line.Contains ("<trigger/>")) {
				triggerLines.Add (line);	
			} else {
				subtitleLines.Add (line);
			}
		}



		//split out 
		for(int  cnt = 0; cnt < subtitleLines.Count; cnt++)
		{
			string[] splitTemp = subtitleLines [cnt].Split ('|');
			subtitleTimingString.Add (splitTemp [0]);
			subtitleTimings.Add (float.Parse (CleanTimeString (subtitleTimingString [cnt])));
			subtitleText.Add (splitTemp [1]);
			
		}
		//to split out Triggers 
		for (int cnt = 0; cnt < subtitleLines.Count; cnt++) {
			string[] splitTemp1 = triggerLines [cnt].Split ('|');
			triggerTimingString.Add (splitTemp1 [0]);
			triggerTimings.Add (float.Parse(CleanTimeString(triggerTimingString[cnt])));
				

			triggers.Add (splitTemp1 [1]);
			string[] splitTemp2 = triggers [cnt].Split ('-');
			splitTemp2 [0] = splitTemp2 [0].Replace ("<trigger/>", "");  
			triggerObjectNames.Add (splitTemp1 [0]);
			triggerMethodNames.Add (splitTemp2 [1]);
		}

		//set initial subtitle text
		if(subtitleText[0] != null)
		{
			displaySubtitle = subtitleText [0];
		}
			

				//setplay audio
		audioSurce.clip = passedClip;
		audioSurce.Play ();
		//audio.Clip = passedClip;
		//audio.Play ();

	}
	//hapus semua karakter yang bukan bagian dari waktu
	private string CleanTimeString(string timeString){
		Regex digitsOnly = new Regex (@"('\d+(\.\d+)'@)");
		return digitsOnly.Replace (timeString, "");
	}
}
