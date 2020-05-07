﻿using UnityEngine;
using System.Collections;

// this script moves the clouds
// set the speed individually via the inspector

public class cloudMove : MonoBehaviour {

	public float speed;
    public float i =12;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// get the actual position
		Vector3 position = transform.position;
		// move it with given speed
		position.x += speed;
		// wrap around, if clouds leave screen to the right
		if (position.x >- i)
			position.x =  i;
		// set the vector
		transform.position = position;
	}
}
