using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
[CustomEditor(typeof(DataContainer))]
public class DataContainerEditor : Editor{
	
	private DataContainer data;
	
	[MenuItem("Assets/Create/DataContainer")]
	static void Create(){

		string path = EditorUtility.SaveFilePanel("Create entity","Assets/","data.asset","asset");
	
		if(path == "")
			return;
		
		path = FileUtil.GetProjectRelativePath(path);
		DataContainer d = CreateInstance<DataContainer>();
		AssetDatabase.CreateAsset(d,path);
		AssetDatabase.SaveAssets();
	}

	private void OnEnable(){
		data = (DataContainer)target;
	}
}
