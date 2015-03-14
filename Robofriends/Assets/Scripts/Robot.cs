using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {
	public PhysicMaterial friction;
	public PhysicMaterial frictionless;
	Rigidbody rigidbody;

	public virtual bool CanJump() {
		return false;
	}

	// Use this for initialization
	void Start () {
		rigidbody = gameObject.GetComponent<Rigidbody>();
		collider.material = friction;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void SetParent(GameObject go) {
		Destroy(gameObject.rigidbody);
		transform.parent = go.transform;

		collider.material = frictionless;
	}

	public virtual void ReleaseParent() {

		Rigidbody rb = gameObject.AddComponent<Rigidbody>() as Rigidbody;

		rb.freezeRotation = true;
		rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionZ;

		rb.velocity = transform.parent.rigidbody.velocity;
		collider.material = friction;

		transform.parent = null;
		
	}
}
