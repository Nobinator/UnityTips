using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Gizmosable))]
public class GizmosableEditor : Editor {

	//Реализация Gizmos в Editor вместо MonoBehaviour
	[DrawGizmo(GizmoType.NonSelected)]
	static void DrawGizmosActive(Gizmosable g, GizmoType gizmoType){
		Gizmos.color = Color.magenta *0.2f;
		Gizmos.DrawCube(g.transform.position,g.transform.localScale);
	}
	
	[DrawGizmo(GizmoType.InSelectionHierarchy)]
	static void DrawGizmos(Gizmosable g, GizmoType gizmoType){
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(g.transform.position,g.transform.localScale);
	}
	
}
