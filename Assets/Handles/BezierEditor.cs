using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Bezier))]
public class BezierEditor : Editor{
	private Bezier b;

	private Vector3 startPos = Vector3.zero;
	private Vector3 endPos = Vector3.zero;
	private Vector3 startTan = Vector3.up;
	private Vector3 endTan = Vector3.up;

	private float tanmultiplier;

	private const float capSize = .03f;

	private void OnEnable(){
		Tools.current = Tool.None;
	}


	private void OnSceneGUI(){



		b = ((Bezier) target);
		var t = b.gameObject.transform;

		/*Handles.color = Color.blue;
		startTan = Handles.PositionHandle(startTan, Quaternion.identity);
		Handles.SphereHandleCap(0,startTan,Quaternion.identity,capSize,EventType.Repaint);
		
		endTan = Handles.PositionHandle(endTan, Quaternion.identity);
		Handles.SphereHandleCap(0,endTan,Quaternion.identity,capSize,EventType.Repaint);
		
		Handles.color = Color.magenta;
		startPos = Handles.FreeMoveHandle(startPos, Quaternion.identity, .1f, Vector3.zero, Handles.SphereHandleCap);
		endPos = Handles.FreeMoveHandle(endPos, Quaternion.identity, .1f, Vector3.zero, Handles.SphereHandleCap);
		*/

		for (int i = 0; i < b.curve.keys.Length - 1; i++){

			var st = new Vector3(b.curve.keys[i].time, b.curve.keys[i].value, 0);
			var en = new Vector3(b.curve.keys[i + 1].time, b.curve.keys[i + 1].value, 0);

			Handles.color = Color.white;
			mark(st, "S", i);
			mark(en, "E", i);
			// через curve углы как то неправильно считаются, не знаю что с этим делать
			var stan = st + Quaternion.AngleAxis(Mathf.Rad2Deg * b.curve.keys[i].outTangent, Vector3.forward) * Vector3.right*b.tanmultiplier;
			var etan = en + Quaternion.AngleAxis(Mathf.Rad2Deg * b.curve.keys[i + 1].inTangent, Vector3.forward) * Vector3.left*b.tanmultiplier;
			
			Handles.DrawLine(st,stan);
			
			Handles.color = Color.red;
			mark(stan, "OutTan", i);
			Handles.color = Color.blue;
			mark(etan, "InTan", i);


			Handles.DrawBezier(st, en, stan, etan, Color.white, null, 1f);

			// Делает из Bezier массив точек.
			foreach(var v in Handles.MakeBezierPoints(st, en, stan, etan, 20)){
				mark(v,"",0);
			}
			
		}

		/*Handles.DrawBezier(
			startPos,
			endPos,
			startTan,
			endTan,
			Color.white,
			null,
			1f);*/
	}

	void mark(Vector3 p,string text, int i){
		Handles.SphereHandleCap(0, p, Quaternion.identity, capSize, EventType.Repaint);
		Handles.Label(p + Vector3.up*0.2f,string.Format(text+" [{0}]",i),EditorStyles.largeLabel);
			
	}


	void OnGUI(){
		b.curve = EditorGUI.CurveField(
			new Rect(3, 3, 100, 100),
			"Animation on X", b.curve);
		
	}

}
