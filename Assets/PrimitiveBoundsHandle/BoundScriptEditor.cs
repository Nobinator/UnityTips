using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
[CustomEditor(typeof(BoundScript))]
public class BoundScriptEditor : Editor {

	private BoundScript bs;
	private BoxBoundsHandle bh;
	private SphereBoundsHandle sp;

	private void OnEnable(){
		bh = new BoxBoundsHandle(GUIUtility.GetControlID(FocusType.Passive)){
			wireframeColor = Color.black,
			handleColor = Color.black
		};

		sp = new SphereBoundsHandle(GUIUtility.GetControlID(FocusType.Passive)){
			wireframeColor = Handles.yAxisColor,
			handleColor = Handles.yAxisColor,
			axes = PrimitiveBoundsHandle.Axes.X | PrimitiveBoundsHandle.Axes.Z
		};

		bs = (BoundScript) target;
		Tools.hidden = true;
	}

	protected virtual void OnSceneGUI(){

		// copy the target object's data to the handles
		bh.center = bs.transform.position;
		bh.size = bs.transform.localScale;

		sp.radius = bs.transform.localScale.x/2;
		sp.center = bs.transform.position + Vector3.up*bs.transform.localScale.y/2;

		EditorGUI.BeginChangeCheck();
		
		sp.DrawHandle();
		bh.DrawHandle();
		
		if (EditorGUI.EndChangeCheck()){
			Undo.RecordObject(bs, "Change Bounds");
			bs.transform.localScale = bh.size;
			bs.transform.position = bh.center;
		}
	}
}
