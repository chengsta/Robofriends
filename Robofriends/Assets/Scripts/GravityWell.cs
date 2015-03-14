using UnityEngine;
using System.Collections;

public class GravityWell : MonoBehaviour {
	public float ForceMultiplier = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	void OnTriggerStay(Collider coll) {
//		if (coll.transform.name == "Player") {
//			print ("s");
//			Vector3 direction = new Vector3(0,0,coll.transform.rotation.z);
//			coll.rigidbody.AddForce (direction * 10.0f, ForceMode.Acceleration);
//		}
//	}
	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.layer == LayerMask.NameToLayer("Player")) {
			// Vector3 direction = new Vector3(1,1,0);
			coll.rigidbody.AddForce (transform.up* ForceMultiplier, ForceMode.Acceleration);
		}
		if (coll.gameObject.layer == LayerMask.NameToLayer("Robot")) {
			coll.transform.parent.rigidbody.AddForce (transform.up* ForceMultiplier, ForceMode.Acceleration);
		}
	}
}
