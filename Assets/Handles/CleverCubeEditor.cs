using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(CleverCube))]
public class CleverCubeEditor : Editor{
	
	// Переменные будут сбиваться постоянно после того, как будет убрано выделение
	private bool forwardArrow = false;
	private int handler = 9;
	private int maxhandler = 14;
	
	
	private CleverCube clv;
	
	protected virtual void OnSceneGUI(){
		clv = (CleverCube) target;
		if (clv == null)
			return;

		var t = clv.transform;
		
		// Handles.BeginGUI
		// Handles.EndGUI
		/* Можно рисовать GUI прямо поверх сцены */
		Handles.BeginGUI();
		
			//if (GUILayout.Button("Forward Arrow", GUILayout.Width(100))){
			//	forwardArrow = true;
				// Вызов Handles не GUI внутри блока BeginGUI - EndGUI не имеет смысла
			//}
		
			if (GUILayout.Button("Handler "+handler, GUILayout.Width(100))){
				handler++;
				if(handler >= maxhandler) handler = 0;
			}
		
		Handles.EndGUI();

		
		if(handler == 0){
			// Стрелка с палочкой
			Handles.ArrowHandleCap(0, t.position + t.forward, t.rotation, .2f, EventType.Repaint);
			
		}else if(handler == 1){
			
			// Handles.Button (Make a 3D Button)
			if (Handles.Button(t.position + Vector3.up*1.3f, t.rotation, .3f, .2f, Handles.RectangleHandleCap))
				Debug.Log("The button was pressed!");
			
		}else if(handler == 2){
			// Окружность
			Handles.color = Handles.zAxisColor;
			Handles.CircleHandleCap(
				0,
				t.position + Vector3.forward*1.2f,
				t.rotation * Quaternion.LookRotation(Vector3.forward),
				t.localScale.z*.5f,// под size, вероятно, подразумевается радиус, ибо всегда в два раза больше назначеррного расстояния.
				EventType.Repaint
			);
			
		}else if(handler == 3){
			// Конус (ArrowHead)
			Handles.color = Handles.zAxisColor;
			Handles.ConeHandleCap(
				0,
				t.position + Vector3.forward*1.2f,
				t.rotation * Quaternion.LookRotation(Vector3.forward),
				0.3f,
				EventType.Repaint
			);
			
		}else if(handler == 4){
			// Куб (ArrowHead)
			Handles.color = Handles.zAxisColor;
			Handles.CubeHandleCap(
				0,
				t.position + Vector3.forward*1.2f,
				t.rotation * Quaternion.LookRotation(Vector3.forward),
				0.3f,
				EventType.Repaint
			);
			
		}else if(handler == 5){
			// Цилиндр (ArrowHead)
			Handles.color = Handles.zAxisColor;
			Handles.CylinderHandleCap(
				0,
				t.position + Vector3.forward*1.2f,
				t.rotation * Quaternion.LookRotation(Vector3.forward),
				0.3f,
				EventType.Repaint
			);
			
		}else if(handler == 6){
			// Make a 3D disc that can be dragged with the mouse
			// Меняет поворот по оси Vector3.up
			t.rotation = Handles.Disc(t.rotation, t.transform.position, Vector3.up, 2, false, 1);

		}else if(handler == 7){
			// Рисует точку (Billboard Square)
			Handles.color = Color.yellow;
			Handles.DotHandleCap(
				0,
				t.position + Vector3.forward*1.2f,
				t.rotation * Quaternion.LookRotation(Vector3.forward),
				0.03f,
				EventType.Repaint
			);
			
		}else if(handler == 8){
			//Draw anti-aliased convex polygon specified with point array.
			var arrowHead = new Vector3[3];
			var arrowLine = new Vector3[2];

			Transform start = t;
			Transform end = clv.second;
			if (!start || !end)
				return;

			var forward = (end.position - start.position).normalized;
			var right = Vector3.Cross(Vector3.up, forward).normalized;
			var size = HandleUtility.GetHandleSize(end.position);
			var width = size * 0.1f;
			var height = size * 0.3f;

			arrowHead[0] = end.position;
			arrowHead[1] = end.position - forward * height + right*width;
			arrowHead[2] = end.position - forward * height - right*width;

			arrowLine[0] = start.position;
			arrowLine[1] = end.position - forward * height;

			Handles.color = Color.red;
			Handles.DrawAAPolyLine(arrowLine);
			Handles.DrawAAConvexPolygon(arrowHead);
			
		}else if(handler == 9){

			// Эта штука не рендерится, или я не вижу или не работает.
			float width = HandleUtility.GetHandleSize(Vector3.zero) * 0.1f;
			Handles.DrawBezier(t.position,
				Vector3.zero,
				Vector3.up,
				-Vector3.up,
				Color.red,
				null,
				width);
			
		}else if(handler == 10){
			
			Handles.DrawDottedLine(t.position, clv.second.transform.position, 20f);
			
			
			//  DrawDottedLines	
			//	DrawLine	
			//	DrawLines	
			//	DrawPolyLine
			
		}else if(handler == 11){
			
			Handles.DrawSolidArc(t.position,
				t.up,
				-t.right,
				180,
				clv.areaRadius);
			
			
			Handles.color = Color.white;
			clv.areaRadius =
				Handles.ScaleValueHandle(clv.areaRadius,
					t.position + t.forward * clv.areaRadius,
					t.rotation,
					1,
					Handles.ConeCap,
					1);
			
		}else if(handler == 12){
		}




	}

	public override void OnInspectorGUI(){
		base.OnInspectorGUI();

		EditorGUI.BeginChangeCheck();
		
		
		//forwardArrow = GUILayout.Toggle(forwardArrow,"Forward Arrow");
		
		
		
		
		if(EditorGUI.EndChangeCheck()){
			SceneView.RepaintAll();// Если не вызвать, то после Toggle стрелка появится только после вызова
		}

	}
}
