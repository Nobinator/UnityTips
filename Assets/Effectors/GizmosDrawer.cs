using UnityEngine;

namespace Effectors{
	public class GizmosDrawer : MonoBehaviour{
		
		
		
		public AreaEffector2D area;

		void OnDrawGizmos() {
			Gizmos.color = Color.red;
			var direction = transform.TransformDirection(Quaternion.Euler(0,0,area.forceAngle)*Vector3.right) * 2;
			Gizmos.DrawRay(transform.position, direction);
		}
	}
}
