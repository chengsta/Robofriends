using UnityEngine;
using System.Collections;

public class GravityWell : MonoBehaviour {
	public float maxSpeed;
	public float Force = 1.0f;
	public enum Direction {
		UP,
		DOWN,
		LEFT,
		RIGHT
	};

	public Direction direction;

	//identity vector for direction of grav
	private Vector3 dir;
	//identity vector for direction to ignore (doesn't affect this dimension of movement)
	private Vector3 keep;


	// Use this for initialization
	void Start () {
		if (direction == Direction.UP) {
			dir = new Vector3(0, 1, 0);
			keep = new Vector3(1, 0, 0);
		}
		else if (direction == Direction.DOWN) {
			dir = new Vector3(0, -1, 0);
			keep = new Vector3(1, 0, 0);
		}
		else if (direction == Direction.LEFT) {
			dir = new Vector3(-1, 0, 0);
			keep = new Vector3(0, 1, 0);
		}
		else {
			dir = new Vector3(1, 0, 0);
			keep = new Vector3(0, 1, 0);
		}
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
	void OnTriggerStay(Collider coll) {
		Rigidbody rb = null;
		if (coll.gameObject.GetComponent<Player>()) {
			rb = coll.rigidbody;
		}
		else if (coll.gameObject.GetComponent<Robot>()) {
			if (coll.GetComponentInParent<Player>())
				rb = coll.transform.parent.rigidbody;
			else
				rb = coll.rigidbody;
		}
		else {
			print ("error, GravityWell.cs OnTriggerEnter()");
			return;
		}

		//if the object is moving higher than the max speed in the direction of the grav well, 
		//don't let it go any faster.
		if (Vector3.Dot(rb.velocity, dir) > maxSpeed) {
			rb.velocity = new Vector3(rb.velocity.x * keep.x, rb.velocity.y * keep.y, 0) + ((maxSpeed + .01f) * dir);
			return;
		}

		rb.AddForce (dir* Force, ForceMode.Acceleration);
	}
}
