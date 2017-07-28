using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour {

	public GameObject linePrefab;

	Line activeLine;
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)){
			if(activeLine == null){
				var go = Instantiate(linePrefab);
				activeLine = go.GetComponent<Line>();
			} else {
				activeLine = null;
			}
		}
		
		if (activeLine != null){
			activeLine.UpdateLine(transform.position);
		}
	}
}
