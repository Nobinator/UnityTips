using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Bezier))]
public class BezierEditor : Editor{
	private Vector3 startPos = Vector3.zero;
	private Vector3 endPos = Vector3.zero;
	private Vector3 startTan = Vector3.up;
	private Vector3 endTan = Vector3.up;

	private const float capSize = .07f;
	
	private void OnEnable(){
		Tools.current = Tool.None;
	}


	private void OnSceneGUI(){

		var t = ((Bezier)target).gameObject.transform;

		Handles.color = Color.blue;
		startTan = Handles.PositionHandle(startTan, Quaternion.identity);
		Handles.SphereHandleCap(0,startTan,Quaternion.identity,capSize,EventType.Repaint);
		
		endTan = Handles.PositionHandle(endTan, Quaternion.identity);
		Handles.SphereHandleCap(0,endTan,Quaternion.identity,capSize,EventType.Repaint);
		
		Handles.color = Color.magenta;
		startPos = Handles.FreeMoveHandle(startPos, Quaternion.identity, .1f, Vector3.zero, Handles.SphereHandleCap);
		endPos = Handles.FreeMoveHandle(endPos, Quaternion.identity, .1f, Vector3.zero, Handles.SphereHandleCap);
		
		
		Handles.DrawBezier(
			startPos,
			endPos,
			startTan,
			endTan,
			Color.white,
			null,
			1f);
		
	}
	
}
