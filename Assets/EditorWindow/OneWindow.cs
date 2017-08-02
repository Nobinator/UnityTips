using System.Globalization;
using UnityEditor;
using UnityEngine;
// ReSharper disable DelegateSubtraction
// ReSharper disable CheckNamespace

public class OneWindow : EditorWindow{
	private float time = 0;
	private bool isTimerStarted = false;

	// Атрибут, добавляющий текущий метод в выпадающий список в меню
	[MenuItem("Window/Nobi/OneWindow")]
	static void OpenWindow(){
		//var window = (OneWindow) GetWindow(typeof(OneWindow));
		//window.minSize = new Vector2(100,100);
		//window.Show();

		var win = EditorWindow.GetWindow<OneWindow>(false,"Title");
		win.minSize = new Vector2(100,100);
	}

	private void OnEnable(){
		
		/*
		EditorApplication.update - коллбек функция, выполняющаяся 30 раз в секунду в любом случае. Работает в edit mode.
		через += мы добавляем делегата (метод), который тоже будет исполняться во время исполнения EditorApplication.update
		*/
		
		EditorApplication.update -= OnUpdate; // удаляем на всякий случай
		EditorApplication.update += OnUpdate; // добавляем
	}

	private void OnDisable(){
		EditorApplication.update -= OnUpdate; // удаляем метод обновления окна при OnDisable
	}

	void OnUpdate(){
		if(isTimerStarted){
			time += Time.deltaTime;
			Repaint(); // Перерисовывает окно принудительно (само оно обновляется только во время прямого взаимодействия)
		}
		
		//SceneView.RepaintAll(); // Перерисовывание сцены (видимо сама она не обновляется)
	}

	private void OnGUI(){
		GUILayout.BeginHorizontal();
			GUILayout.Label("Time ",EditorStyles.boldLabel,GUILayout.Width(50f));
			GUILayout.Label(time.ToString(CultureInfo.CurrentCulture),EditorStyles.boldLabel);
		GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
			if(GUILayout.Button("Start",GUILayout.Height(30f))){
				isTimerStarted = true;
			}
			
			if(GUILayout.Button("Stop",GUILayout.Height(30f))){
				isTimerStarted = false;
			}
			if(GUILayout.Button("Reset",GUILayout.Height(30f))){
				time = 0;
			}
		GUILayout.EndHorizontal();
		
		GUI.backgroundColor = Color.blue;
		GUILayout.Button("X");
	}


	/*
	
	EditorPrefs
	
	bool isLevelEditorMode = EditorPrefs.GetBool("isLevelEdMode",true);
	
	*/
}