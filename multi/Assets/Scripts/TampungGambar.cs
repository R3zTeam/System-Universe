using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TampungGambar : MonoBehaviour {



	public Image imageGambar;

	public Sprite bacan;
	public Sprite dewi;


	// Use this for initialization
	void Start () {
		
	}

	public void GambarBacan() 
	{
		imageGambar.sprite = bacan;
	}

	public void GambarDewi() 
	{
		imageGambar.sprite = dewi;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
