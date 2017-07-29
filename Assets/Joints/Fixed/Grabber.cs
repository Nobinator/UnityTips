using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour{

	public FixedJoint fj;
	public bool isGrabbing;
	public Material m;

	void Start(){
		m.color = isGrabbing ? Color.yellow : Color.gray;
	}

	private void OnTriggerEnter(Collider other){
		if(!isGrabbing) return;
		
		var r = other.gameObject.GetComponent<Rigidbody>();
		if(r == null) return;
		
		fj.connectedBody = r;
		m.color = Color.green;
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.F)){
			if(isGrabbing){
				isGrabbing = false;
				fj.connectedBody = null;
				m.color = Color.gray;
			}
			else{
				isGrabbing = true;
				m.color = Color.yellow;
			}
		}
		}
}
