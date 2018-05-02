﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carwheel : MonoBehaviour {

    public WheelCollider TargetWheel;
    private Vector3 wheelPosition = new Vector3();
    private Quaternion wheelRotation = new Quaternion();
     

	private void Update () {

        TargetWheel.GetWorldPose(out wheelPosition, out wheelRotation);
        transform.position = wheelPosition;
        transform.rotation = wheelRotation;

	}
}
