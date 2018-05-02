﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayVoiceOver : MonoBehaviour {

	private AudioSource audioSource;


	private void Awake(){
		audioSource = GetComponent<AudioSource> ();

	}
	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("mobil"))
        {
            audioSource.Play();


        }
        else {
            audioSource.Play();
        }
	}
}
