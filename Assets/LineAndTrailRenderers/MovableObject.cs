using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour{

	public const float movingSpeed = 0.05f;
	
	void Update () {
		if(Input.GetKey(KeyCode.A)){
			transform.Translate(Vector3.left * movingSpeed);
		}
		if(Input.GetKey(KeyCode.D)){
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
