using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(ContextMenuObject))]
public class GenericContextMenuEditor : Editor{
	
	/////////////////////
	// NOTHING IS HERE //
	/////////////////////
	
	private void OnSceneGUI(){


		/*if(Event.current.control){
			Debug.Log("HI");
		}*/

		//Handles.CircleHandleCap(GUIUtility.GetControlID(FocusType.Passive), Vector3.up, Quaternion.identity, 1f, EventType.Repaint);
		
		/*EventListener(GUIUtility.GetControlID(FocusType.Passive), () => {
			GenericMenu menu = new GenericMenu();
			
			menu.AddItem(new GUIContent("Item1"), false, Click);
			menu.AddItem(new GUIContent("Item2"), false, Click);
			menu.AddSeparator("");
			menu.AddItem(new GUIContent("Item3"), false, Click);
			menu.AddItem(new GUIContent("Item4"), false, Click);
			
			menu.ShowAsContext();
		});*/
		
	}

	void Click(){
		Debug.Log("Click");
	}


	public static void EventListener(int controlID, Action action){
		
		/*var v = Event.current.GetTypeForControl(controlID);
		if(v!= EventType.MouseMove)
			Debug.Log(v+ " %%%% "+Event.current );
		
		if(v != EventType.ContextClick) return;
		
		action();
		GUIUtility.hotControl = 0;
		GUIUtility.keyboardControl = 0;
		Event.current.Use();*/

		//Debug.Log(Event.current);
		var current = Event.current;
		switch (current.GetTypeForControl(controlID)) {
			case EventType.ContextClick:
				//if (HandleUtility.nearestControl == controlID /*&& _contextClickID == controlID*//*) 
				{
					//_contextClickID = 0;
					action();
					GUIUtility.hotControl = 0;
					GUIUtility.keyboardControl = 0;
					current.Use();
				}
				break;
			case EventType.mouseDown:
				if (HandleUtility.nearestControl == controlID) {
					if (current.button == 1) {
						//_contextClickID = controlID;
						GUIUtility.hotControl = 0;
						GUIUtility.keyboardControl = 0;
						Event.current.Use();
					}
				}
				break;
		}
	}
}
