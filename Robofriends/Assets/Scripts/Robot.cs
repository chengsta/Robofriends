using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {
	Rigidbody rigidbody;

	public virtual bool CanJump() {
		return false;
	}

	// Use this for initialization
	void Start () {
		rigidbody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetParent(GameObject go) {
		Destroy(gameObject.rigidbody);
		transform.parent = go.transform;
		
	}

	public void ReleaseParent() {
		transform.parent = null;
		Rigidbody rb = gameObject.AddComponent<Rigidbody>() as Rigidbody;

		rb.freezeRotation = true;
		rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionZ;
		
	}
}
