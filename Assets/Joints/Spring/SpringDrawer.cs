using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringDrawer : MonoBehaviour{
	private SpringJoint[] sjs;

	void Start(){
		sjs = GetComponents<SpringJoint>();
	}

	/*void Update(){
		foreach(var sj in sjs){
			Debug.DrawLine(sj.anchor,sj.connectedAnchor,Color.cyan);
		}
	}*/
}
