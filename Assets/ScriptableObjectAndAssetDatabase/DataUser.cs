using UnityEngine;
public class DataUser : MonoBehaviour{
	private DataContainer d;
	
	void Start(){
		d = DataContainer.Instance;
	}

	private void Update(){
		transform.Rotate(Vector3.up,d.angle,Space.Self);
	}
}