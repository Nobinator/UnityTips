using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Bezier))]
public class BezierEditor : Editor{
	private Bezier b;

	/*private Vector3 startPos = Vector3.zero;
	private Vector3 endPos = Vector3.zero;
	private Vector3 startTan = Vector3.up;
	private Vector3 endTan = Vector3.up;*/

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
		
		/*Handles.DrawBezier(startPos,endPos,startTan,endTan,Color.white,null,1f);*/

		
		for (int i = 0; i < b.curve.keys.Length - 1; i++){

			// Рассчет начальной и конечной точки
			var st = new Vector3(b.curve.keys[i].time, b.curve.keys[i].value, 0);
			var en = new Vector3(b.curve.keys[i + 1].time, b.curve.keys[i + 1].value, 0);

			// Маркировка точек
			Handles.color = Color.white;
			mark(st, "S", i);
			mark(en, "E", i);

			// Рассчет тангент
			var stan = st + (Vector3.right + Vector3.up * b.curve.keys[i].outTangent).normalized * b.tanmultiplier;
			var etan = en + (-Vector3.right + Vector3.up * -b.curve.keys[i + 1].inTangent).normalized * b.tanmultiplier;
			
			// Маркировка тангент
			Handles.color = Color.red;
			mark(stan, "OutTan", i);
			Handles.color = Color.blue;
			mark(etan, "InTan", i);

			// Отрисовка кривой
			Handles.DrawBezier(st, en, stan, etan, Color.white, null, 1f);

			// ====================================================================================================== //
			
			Handles.color = Color.black;
			
			//Handles.MakeBezierPoints возвращаем массив точек, собраных с заданой кривой с заданым интервалом
			var points = Handles.MakeBezierPoints(st, en, stan, etan, 20);
			var polygon = new Vector3[points.Length + 2]; // Две доп точки по краям

			// Первая точка
			polygon[0] = points[0];
			polygon[0].y = 0;
			//mark(polygon[0],"V",0);
			
			// Последняя точка
			polygon[polygon.Length - 1] = points[points.Length - 1];
			polygon[polygon.Length - 1].y = 0;
			//mark(polygon[polygon.Length - 1],"V",polygon.Length - 1);
			
			// Заполнение промежутков
			for (var j = 0; j < points.Length; j++){
				polygon[j+1] = points[j];
				//mark(polygon[j],"v",j);
			}
			//Отрисовка
			Handles.DrawAAConvexPolygon(polygon);
			
		}
	}

	void mark(Vector3 p,string text, int i){
		Handles.SphereHandleCap(0, p, Quaternion.identity, capSize, EventType.Repaint);
		Handles.Label(p + Vector3.up*0.2f,string.Format(text+" [{0}]",i),EditorStyles.largeLabel);
	}

}
