using UnityEngine;
using System.Collections;

public class RobotGrav : Robot {
	public float up_velocity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator ReverseGrav () {
		while (true) {
//			print ("start of grav coroutine");
			GetComponentInParent<Rigidbody>().useGravity = false;
			Vector3 new_velocity = GetComponentInParent<Rigidbody>().velocity;
			new_velocity.y += up_velocity;
			GetComponentInParent<Rigidbody>().velocity = new_velocity;

//			print (new_velocity);

			yield return null;
		}
	}

}
