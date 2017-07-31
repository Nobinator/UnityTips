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
			
				if(GUILayout.Button("Rotation",GUILayout.Height(30))){
					cube.DoRotation();
				}
			
				GUILayout.Space(20);
				
				// Стили передаются массивом патаметров через запятую
				if(GUILayout.Button("Reset",GUILayout.Height(30),GUILayout.Width(80))){
					cube.Reset();
				}
			
			GUILayout.EndHorizontal();
			
			GUILayout.Label("BoldLabel", EditorStyles.boldLabel);
			
			/* Если в блоке кода между
				BeginChangeCheck и EndChangeCheck 
			   поменяется значение любого из полей, содержащихся в блоке, то EndChangeCheck вернет true.
			   Изменения казаются именно полей, а не самих переменных, так, нажав Rotation EndChangeCheck не сработает.
			   т.е работает только при изменении ручками.
			*/
			EditorGUI.BeginChangeCheck();
			
			cube.transform.localScale = Vector3.one * EditorGUILayout.Slider("Size",cube.transform.localScale.x, .1f, 2f);

			cube.transform.rotation = Quaternion.Euler(
				0,
				// Поле сразу возвращает то значение, которое ему назначено в инспекторе и отображает всегда второй аргумент
				EditorGUILayout.FloatField("Angle",cube.transform.rotation.eulerAngles.y),
				0);
			
			if(EditorGUI.EndChangeCheck()){
				Debug.Log("Changed");
			}
			
			
			if(GUILayout.Button("Beep")){
				// Проигрывает системный звук
				EditorApplication.Beep();
			}
			
			if(GUILayout.Button("Reset (Dialog)")){

				if(EditorUtility.DisplayDialog("Reset this?", "Are you really awnt to do this?", "Yes", "No")){
					//yes 
					cube.Reset();
				}else{
					//no
					Debug.Log("Nothing");
				}


			}
			
			// Фичи, о которых следует узнать подробнее
			
			// Позволяет получать доступ к существующим сериализованным объектам? Нужно поподробнее разобраться
			//SerializedProperty prop = serializedObject.FindProperty("State");
			
			// Какая-то фича с сохранением изменений
			//EditorUtility.SetDirty(obj);
			
			// ReordableList
			

		}
	}
	
}
