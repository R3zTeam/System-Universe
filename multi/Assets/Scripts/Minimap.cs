using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {

	public Transform Character_Dewi;


	void LateUpadate() 
	{
		Vector3 newPosition = Character_Dewi.position;
		newPosition.y = transform.position.y;
		transform.position = newPosition;



	}


}
