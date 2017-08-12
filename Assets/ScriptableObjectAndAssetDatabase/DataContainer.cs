using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[Serializable]
public class DataContainer : ScriptableObject{
	public float angle;
	public int attackDamage;
	public string description;
	public Texture2D avatar;

	private static DataContainer _instance;

	private static readonly string path = "Assets/ScriptableObjectAndAssetDatabase/data.asset"; 

	public static DataContainer Instance
	{
		get
		{
			if(_instance == null){
				_instance = AssetDatabase.LoadAssetAtPath<DataContainer>(path);
				if(_instance == null){
					Debug.Log("New DataContainer");
					_instance = CreateInstance<DataContainer>();
					AssetDatabase.CreateAsset(_instance,path);
					AssetDatabase.SaveAssets();
				}
			}
			return _instance;
		}
	}
}
