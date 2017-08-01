using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Plane))]
public class PlaneEditor : Editor{
	
	private SerializedProperty pointProp;
	private Plane p;
	
	private void OnEnable(){
		p = (Plane) target;
		//!//pointProp = serializedObject.FindProperty("point");
		//serializedObject - это представление выбранного объекта в сериализованном виде
		/*
		[?] Зачем искать prop, если можно обратиться напрямую к target?
		Вероятно есть какой-то уровень абстракции, когда для работы нужен такой подход
		
		
		*/
	}

	private void OnSceneGUI(){
		//PointMovement();

		DrawOverlay();

	}

	void DrawOverlay(){
		Handles.DrawLine(Vector3.zero, p.point);

		Vector2 pos = HandleUtility.WorldToGUIPoint(p.point);
		if(p.point.x < 0){
			pos.x -= 100;
		}
		Vector2 size = new Vector2(100,50);
		Rect screenRect = new Rect(pos.x,pos.y,size.x,size.y);
		Handles.BeginGUI();
		GUI.Box(screenRect,"Глобально точка тут");
		Handles.EndGUI();
		
		
		// Доп фича если вдруг пригодится GetWorldUnitsPerPixel(Camera.current)
	}

	void PointMovement(){
		// transform.TransformPoint делает так, будто вектор - аргумент работает
		// относительно текущего трансформа, применяя его позицию и поворот, а не мира.
		// т.е буквально кладев вектор в локальное пространство трансформа
		Vector3 worldPoint = p.transform.TransformPoint(p.point);

		// Такая фича позволяет сохранять размер элементов даже при изменении зума камеры сцена и прочего.
		float size = HandleUtility.GetHandleSize(worldPoint);

		worldPoint = Handles.FreeMoveHandle(worldPoint, Quaternion.identity, size * 0.1f, Vector3.zero, Handles.RectangleHandleCap);
		
		
		// обратное к transform.TransformPoint действие
		p.point = p.transform.InverseTransformPoint(worldPoint);
		
		Handles.DrawLine(p.transform.position,worldPoint);
		Handles.DrawLine(Vector3.zero, p.point);
	}
}
