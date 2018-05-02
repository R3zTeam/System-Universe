using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carEngine : MonoBehaviour {

    public Transform path;
    public float maxSteerAngle = 45f;
    public WheelCollider wheelR;
    public WheelCollider wheeLL;

    private List<Transform> nodes;
    private int currectNode = 0;

    public float MaxMotorTorque = 120f;
    public float currentSpeed;
    public float maxSpeed = 150f;
    public Vector3 centerOfMass;
    

    


/*
    [Header("Sensors")]
    public float sensorLength = 10f;
    public Vector3 FrontSensorPosotion = new Vector3(0f, 0.2f, 0.5f); 
    public float FrontSideSensorPosition = 1.17f;
    public float FrontSensorAngle = 15.05f;
    private bool Avoiding = false;
    */
      
     



    private void Start () {

        GetComponent<Rigidbody>().centerOfMass = centerOfMass; 

        Transform[] pathTransform = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        for (int i = 0; i < pathTransform.Length; i++)
        {
            if (pathTransform[i] != path.transform)
            {
                nodes.Add(pathTransform[i]);

            }
        }

    }
    
	private void FixedUpdate () {
    //    Sensors();
        ApplySteer();
        Drive();
        CheckWaypointDistance();

	}

  
  /*  private void Sensors()
    {
        RaycastHit hit;
        Vector3 sensorStartPos = transform.position;
        sensorStartPos += transform.forward * FrontSensorPosotion.z;
        sensorStartPos += transform.up * FrontSensorPosotion.y;
        float AvoidMulti = 0;
        Avoiding = false;



        //sensor depan
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength)) {
            if (!hit.collider.CompareTag("Terrain")) {

                Debug.DrawLine(sensorStartPos, hit.point);
                Avoiding = true;
            }
            
        }
       
        //sensor kanan 
        sensorStartPos  += transform.right * FrontSideSensorPosition;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
        {
            if (!hit.collider.CompareTag("Terrain"))
            {

                Debug.DrawLine(sensorStartPos, hit.point);
                Avoiding = true;
                AvoidMulti -= 1f;
            }
        }
        
        //sensor kanan angle
        if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(FrontSensorAngle, transform.up)* transform.forward, out hit, sensorLength))
        {
            if (!hit.collider.CompareTag("Terrain"))
            {

                Debug.DrawLine(sensorStartPos, hit.point);
                Avoiding = true;
                AvoidMulti -= 0.5f;
            }
        }

        //sensor kiri 
        sensorStartPos -= transform.right * FrontSideSensorPosition * 2;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
        {
            if (!hit.collider.CompareTag("Terrain"))
            {

                Debug.DrawLine(sensorStartPos, hit.point);
                Avoiding = true;
                AvoidMulti += 1f;
            }
        }
       
        //sensor kiri angle
       else if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(-FrontSensorAngle, transform.up) * transform.forward, out hit, sensorLength))
        {
            if (!hit.collider.CompareTag("Terrain"))
            {

                Debug.DrawLine(sensorStartPos, hit.point);
                Avoiding = true;
                AvoidMulti += 0.5f;
            }
        }

        if (Avoiding) {
            wheeLL.steerAngle = maxSteerAngle * AvoidMulti;
            wheelR.steerAngle = maxSteerAngle * AvoidMulti;

        }
      
    }*/

    private void ApplySteer() {
 
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currectNode].position);
        relativeVector /= relativeVector.magnitude;
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        wheeLL.steerAngle = newSteer;
        wheelR.steerAngle = newSteer;
    }
  private void Drive() {
        currentSpeed = 2 * Mathf.PI * wheeLL.radius * wheelR.rpm * 60 / 10000;

        if (currentSpeed < maxSpeed)
        {
            wheelR.motorTorque = MaxMotorTorque;
            wheeLL.motorTorque = MaxMotorTorque;
        }
        else {
            wheelR.motorTorque = 0;
            wheeLL.motorTorque = 0;
        }
        

    }
    private void CheckWaypointDistance() {
        if (Vector3.Distance(transform.position, nodes[currectNode].position) < 0.5f) {
            if (currectNode == nodes.Count - 1)
            {
                currectNode = 0;
            }
            else {
                currectNode++;
            }
        }
    }
}
