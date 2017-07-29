using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor {

	public override void OnInspectorGUI(){
		MapGenerator m = (MapGenerator) target;

		// Если какое-то из значений было изменено
		if(DrawDefaultInspector()){
			if(m.autoUpdate)
				m.GenerateMap();
		}

		if(GUILayout.Button("Generate")){
			m.GenerateMap();
		}
	}

}
