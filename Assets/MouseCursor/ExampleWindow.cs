using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AddCursorRectExample : EditorWindow{
	[MenuItem("Window/Nobi/AddCursorRect Example")]
	static void addCursorRectExample(){
		AddCursorRectExample window =
			EditorWindow.GetWindowWithRect<AddCursorRectExample>(new Rect(0, 0, 180, 80));
		window.Show();
	}

	void OnGUI(){
		int count = 22;
		int pad = 6;
		int size = 16;
		int sp2 = size + pad * 2;
		int sp1 = size + pad;
		EditorGUI.DrawRect(new Rect(0, 0, count * (sp1) + pad, sp2), new Color(0.5f, 0.5f, 0.85f));
		for (int i = 0; i < count; i++){
			Rect r = new Rect(pad * (i + 1) + i * (size), pad, size, size);
			EditorGUI.DrawRect(r, Color.white);
			EditorGUIUtility.AddCursorRect(r, GetMouse(i));
		}
	}

	MouseCursor GetMouse(int i){
		switch(i){

			case 0: return MouseCursor.Arrow;
			case 1: return MouseCursor.ArrowMinus;
			case 2: return MouseCursor.ArrowPlus;
			case 3: return MouseCursor.CustomCursor;
			case 4: return MouseCursor.FPS;
			case 5: return MouseCursor.Link;
			case 6: return MouseCursor.MoveArrow;
			case 7: return MouseCursor.Orbit;
			case 8: return MouseCursor.Pan;
			case 9: return MouseCursor.ResizeHorizontal;
			case 10: return MouseCursor.ResizeUpLeft;
			case 11: return MouseCursor.ResizeUpRight;
			case 12: return MouseCursor.ResizeVertical;
			case 13: return MouseCursor.RotateArrow;
			case 14: return MouseCursor.ScaleArrow;
			case 15: return MouseCursor.SlideArrow;
			case 16: return MouseCursor.SplitResizeLeftRight;
			case 17: return MouseCursor.SplitResizeUpDown;
			case 18: return MouseCursor.Text;
			case 19: return MouseCursor.Zoom;
			default: return MouseCursor.Arrow;
		}
	}
}