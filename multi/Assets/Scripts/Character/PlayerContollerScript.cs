using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContollerScript : MonoBehaviour {
    public Intractable focus;

    public float walkSpeed = 2;
    public float runSpeed = 3;

    public float turnSmoothSpeed = 0.2f;
    Animator animator;
    float turnSmoothVelocity;
	
    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;
    
    Transform cameraT;
    CharacterController controller;

    // Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        cameraT = Camera.main.transform;
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {

       
        
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        if(inputDir  != Vector2.zero){
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
           transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y,targetRotation,ref turnSmoothVelocity,turnSmoothSpeed);
            
        }
        //bool running = Input.GetKey(KeyCode.LeftShift);
		bool running = Input.GetKey(KeyCode.JoystickButton5);


        float Targetspeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, Targetspeed, ref speedSmoothVelocity, speedSmoothTime);


        //Script lari tanpa camera maju//
            //transform.Translate(transform.forward * Targetspeed * Time.deltaTime, Space.World);
            //float animationSpeedPercent = ((running) ? 1 : .5f) * inputDir.magnitude;


        //end
        //script camera maju berhenti pas kena benda//
        Vector3 velocity = transform.forward * currentSpeed;
        controller.Move(velocity * Time.deltaTime);
        currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;


        float animationSpeedPercent = ((running) ? currentSpeed/runSpeed : currentSpeed/walkSpeed * .5f);
        //end
        animator.SetFloat("Speed",animationSpeedPercent,speedSmoothTime,Time.deltaTime);


     }
    void OnTriggerEnter(Collider other)
    {

       
        if (other.gameObject.tag == "Items")
        {

        }


    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Items")
        {
            
        }

    }
}
