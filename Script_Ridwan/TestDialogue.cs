using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour {
	public AudioClip dialogueClip;
	//public AudioSource dialogueClipTwo;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.JoystickButton0)) {
			AnotherDialogueManager.Instance.BeginDialogue (dialogueClip);
		}
	}
}
