using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAppear : MonoBehaviour {
	
	public GameObject MapUI;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Joystick1Button6))
		{
			MapUI.SetActive(!MapUI.activeSelf);
		}

	}
}
