using UnityEditor;
using UnityEngine;

namespace CustomInspector{
	
	[CustomEditor(typeof(Cube))]
	public class CubeEditor : Editor {
	
		public override void OnInspectorGUI(){
			// Отрисовка стандартного инспектора
			base.OnInspectorGUI();
			// traget - текущий объект взаимодействия
			var cube = (Cube) target;
			
			// GUILayout для взаимодействия со статичными полями и кнопками (label, button, ...)
			// EditorGUILayour для взаимодействия с динамичными полями (float field, int field, slider, ...)
			
			// Внутри блока элементы будут находится на одной строчке
			GUILayout.BeginHorizontal();
			
				if(GUILayout.Button("Rotation")){
					cube.DoRotation();
				}
			
				GUILayout.Space(20);
				
				if(GUILayout.Button("Reset")){
					cube.Reset();
				}
			
			GUILayout.EndHorizontal();
			
			cube.transform.localScale = Vector3.one * EditorGUILayout.Slider("Size",cube.transform.localScale.x, .1f, 2f);

			cube.transform.rotation = Quaternion.Euler(
				0,
				// Поле сразу возвращает то значение, которое ему назначено в инспекторе и отображает всегда второй аргумент
				EditorGUILayout.FloatField("Angle",cube.transform.rotation.eulerAngles.y),
				0);
			
			GUILayout.Space(20);
			
			GUILayout.Label("Vertical box");
			
			GUILayout.BeginVertical("box");
				GUILayout.Label("No interactive slider");
				GUILayout.HorizontalSlider(.5f, 1, 2);
			GUILayout.EndVertical();
		}
	}
	
}
