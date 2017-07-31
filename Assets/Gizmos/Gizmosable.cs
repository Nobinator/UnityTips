using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmosable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Рисует всегда
	private void OnDrawGizmos(){
		Gizmos.color = Color.magenta *0.2f;
		Gizmos.DrawCube(transform.position,transform.localScale);
	}

	// Рисует только при выделении
	private void OnDrawGizmosSelected(){
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(transform.position,transform.localScale);
	}
}
