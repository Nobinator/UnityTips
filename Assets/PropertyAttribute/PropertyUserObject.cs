using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyUserObject : MonoBehaviour{
	
	
	// Кастомный атрибут
	[FloatRange(-1f,1f)] //using this will make the randomModulator appear with double handles.
	public FloatRange randomModulator;

	[Space(10)] public float a;
	void Update(){
	}
}
