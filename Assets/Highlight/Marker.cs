using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Marker : MonoBehaviour {

	[MenuItem("Window/Nobi/Marker/Do highlight")]
	public static void Do(){
		Highlighter.Highlight("Inspector","Scale");
	}
	
	[MenuItem("Window/Nobi/Marker/Stop highlight")]
	public static void Stop(){
		Highlighter.Stop();
	}
}
