using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class readTxt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	 StreamReader reader = new StreamReader("./Assets/dialoguetext.txt");
        String itemStrings = reader.ReadLine();
        char[] delimiter = { '@' };


        while (itemStrings != null)
        {
            string[] fields = itemStrings.Split(delimiter);

            for (int i = 0; i < fields.Length; i++)
            {
                Debug.Log("Primary key is " + i + ". The data is " + fields[i]);
            }

            itemStrings = reader.ReadLine();

            
        }	
	}	
	
	
	// Update is called once per frame
    void Update()
    {
    }
}
