using UnityEngine;
using System.Collections;

public class AirBot : Robot {
	public float speed = 1f;
	public float movementWidth = 0f;
	private Vector3 center;
	private float tetherLength = 0f;
	private GameObject player;
	
	// Use this for initialization
	void Start () {
		player = null;
		center = transform.position;
		GetComponent<Collider>().material = friction;
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(transform.position.x - center.x) > movementWidth)
			speed *= -1f;
		if (movementWidth != 0)
			GetComponent<Rigidbody>().MovePosition(transform.position + transform.right * speed * Time.deltaTime);


	}

	public override void SetParent(GameObject go) {
		tetherLength = Vector3.Distance (go.transform.position, transform.position);
		transform.gameObject.GetComponent<HingeJoint> ().connectedBody = go.GetComponent<Rigidbody>();
		player = go;
		GetComponent<Collider>().material = frictionless;
	}
	
	public override void ReleaseParent() {
		transform.gameObject.GetComponent<HingeJoint> ().connectedBody = null;
		player = null;
	}
}
