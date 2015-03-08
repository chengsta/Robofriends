using UnityEngine;
using System.Collections;

public class GunRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 clickPos =  UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 direction = clickPos - transform.position;
		//		direction.z = 0;
		//		Quaternion rotation = Quaternion.LookRotation(direction);
		//		transform.FindChild("Gun").transform.rotation = rotation;
		
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}
}
