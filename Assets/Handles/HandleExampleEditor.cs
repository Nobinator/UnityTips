using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TargetScript))]

class HandleExampleEditor : Editor{
	
	protected virtual void OnSceneGUI(){
		TargetScript handleExample = (TargetScript)target;

		if (handleExample == null)
			return;

		Handles.color = Color.yellow;

		GUIStyle style = new GUIStyle();
		style.normal.textColor = Color.green;

		Vector3 position = handleExample.transform.position + Vector3.up * 2f;
		string posString = position.ToString();

		Handles.Label(position,
			posString + "\nShieldArea: " +
			handleExample.shieldArea.ToString(),
			style
		);

		Handles.BeginGUI();
		if (GUILayout.Button("Reset Area", GUILayout.Width(100)))
		{
			handleExample.shieldArea = 5;
		}
		Handles.EndGUI();

		Handles.DrawWireArc(
			handleExample.transform.position,
			handleExample.transform.up,
			-handleExample.transform.right,
			180,
			handleExample.shieldArea);

		handleExample.shieldArea =
			Handles.ScaleValueHandle(handleExample.shieldArea,
				handleExample.transform.position + handleExample.transform.forward * handleExample.shieldArea,
				handleExample.transform.rotation,
				1, Handles.ConeHandleCap, 1);
	}
}