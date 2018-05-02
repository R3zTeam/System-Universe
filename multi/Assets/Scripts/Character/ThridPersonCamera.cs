using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThridPersonCamera : MonoBehaviour {
  
    float yaw;
    float pitch;

    public bool lockCursor;
   
    public float mouseSensitiv = 0.5f;
    public Transform target;
    public float dstFromTarget;
    public Vector2 pitchMinMax = new Vector2(-50, 85);


    public float rotationSmoothTime = .12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

	// Use this for initialization
	void Start () {
       if(lockCursor){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        
        }
            
	}
	
	// Update is called once per frame
	void LateUpdate () {

     

        yaw += Input.GetAxis("J_MainHorizontal") * mouseSensitiv;//mouse X
        //horizontal
        pitch -= Input.GetAxis("J_MainVertical") * mouseSensitiv;//mouse Y
        //Vertical
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        //camera colision
       
        //camera colision end
    
           
        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;

        transform.position = target.position - transform.forward * dstFromTarget;
        
	}
}
