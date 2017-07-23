using UnityEngine;

namespace CustomInspector{
	public class Cube : MonoBehaviour {

		public void DoRotation(){
			transform.rotation = Quaternion.Euler(0,Random.Range(-30f,30f),0);
		}
		
		public void Reset(){
			transform.rotation = Quaternion.identity;
		}

	}
}
