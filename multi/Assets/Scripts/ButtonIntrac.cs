using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIntrac : MonoBehaviour {
    public GameObject buttonX;
	public GameObject buttonY;
    public bool ButtonDown;
	// Use this for initialization
	void Start () {
        buttonX = GameObject.Find("Image");
        buttonX.gameObject.SetActive(false);
		buttonY = GameObject.Find("kazumi");
		buttonY.gameObject.SetActive(false);

    }
    void OnTriggerEnter(Collider other) {
 

        if(other.gameObject.tag == "Player"){
            
            ButtonDown = true;
            buttonX.gameObject.SetActive(true);    
			buttonY.gameObject.SetActive(true);    
        }
        
    }
    void OnTriggerExit(Collider other) { 
        if(other.tag == "Player")
        {
            ButtonDown = false;
            buttonX.gameObject.SetActive(false);
			buttonY.gameObject.SetActive(false);
        }

    }
	// Update is called once per frame
	void Update () {
		
	}

}
