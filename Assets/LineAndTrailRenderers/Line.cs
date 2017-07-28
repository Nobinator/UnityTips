using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

	public LineRenderer lineRenderer;

	List<Vector3> points;

	public void UpdateLine (Vector3 point){
		if (points == null){
			points = new List<Vector3>();
			SetPoint(point);
			return;
		}

		if (Vector3.Distance(points.Last(), point) > .1f)
			SetPoint(point);
	}

	void SetPoint (Vector3 point){
		points.Add(point);

		lineRenderer.positionCount = points.Count;
		lineRenderer.SetPosition(points.Count - 1, point);
	}

}