using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour{

	public float movingSpeed = 0.05f;
	public float angularSpeed = 2f;

	public bool angularRule = true;
	
	void Update () {
		if(Input.GetKey(KeyCode.A)){
			if(angularRule)
				transform.Rotate(Vector3.up,-angularSpeed);
			else
				transform.Translate(Vector3.left * movingSpeed);
		}
		if(Input.GetKey(KeyCode.D)){
			if(angularRule)
				transform.Rotate(Vector3.up,angularSpeed);
			else
				transform.Translate(Vector3.right * movingSpeed);
		}
		if(Input.GetKey(KeyCode.W)){
			transform.Translate(Vector3.forward * movingSpeed);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Translate(Vector3.back * movingSpeed);
		}
	}
}
