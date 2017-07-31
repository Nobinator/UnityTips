using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
// ReSharper disable DelegateSubtraction
// ReSharper disable Unity.InvalidStaticModifier

//Атрибут, отвечающий за загрузку (вызов конструктора) текущего скрипта во время старта Unity или во время перекомпиляции 
[InitializeOnLoad]
public class CubeHandle : Editor {

	/*
	
	Очень похоже на Gizmos, но тут, видимо, больше возможностей
	Фишечка текущей расстановки в том, что работает для любых объектов и без крепления скрипта к объектам, как требует Gizmos
	
	
	тут юзается в CustomEditor
	https://docs.unity3d.com/ScriptReference/Handles.CubeHandleCap.html
	
	тут самостоятельно, но не понятно откуда координату мыши берет
	https://www.youtube.com/watch?v=9bHzTDIJX_Q&feature=youtu.be&t=48m21s
	*/
	
	static CubeHandle(){
		// Коллбек цункция позволяет вызывать OnSceneGUI каждый раз, когда сцена перерисовывается.
		// как EditorApplication.update -= OnUpdate; в EditorWindow
		SceneView.onSceneGUIDelegate -= OnSceneGUI;
		SceneView.onSceneGUIDelegate += OnSceneGUI;
		
	}

	private void OnDestroy(){
		SceneView.onSceneGUIDelegate -= OnSceneGUI;
	}

	static void OnSceneGUI(SceneView sceneView){
		
		// Selection позволяет работать с выбранными в текущий момент объектами
		var curr = Selection.activeGameObject;
		
		if(curr != null){
			//Handles.DrawWireCube(curr.transform.position, Vector3.one);
			
			//On EventType.Repaint event, draws the handle shape.
			Handles.ConeHandleCap(999,curr.transform.position + Vector3.up*2,Quaternion.Euler(90,0,0), .5f,EventType.Repaint);	
			
			Handles.Label(curr.transform.position + Vector3.up*2.5f,"Это надпись и стрелка\nнад выбранным\nобъектом",EditorStyles.boldLabel);
			
			
		}
	}
}