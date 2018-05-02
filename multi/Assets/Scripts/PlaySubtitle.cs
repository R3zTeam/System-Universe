﻿using System.Collections;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class PlaySubtitle : MonoBehaviour {

	private AudioSource audioSource;
	private ScriptManager scriptManager;
	private SubtitleGuiManager GuiManager;


	private void Awake(){

		scriptManager = FindObjectOfType<ScriptManager> ();
		audioSource = GetComponent<AudioSource> ();
		GuiManager = FindObjectOfType<SubtitleGuiManager> ();


	}
	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("mobil"))
        {
            StartCoroutine(DoSubtitle());

        }
        else {
            StartCoroutine(DoSubtitle());
        }
	}

	private IEnumerator DoSubtitle()
	{
		var script = scriptManager.GetText (audioSource.clip.name);
		var lineDuration = audioSource.clip.length / script.Length;


		foreach (var line in script) {
			
			GuiManager.SetText (line);
			yield return new WaitForSeconds (lineDuration);
		}

		GuiManager.SetText (string.Empty);

	}
}
