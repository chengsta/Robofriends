using UnityEngine;
using System.Collections;

public class DoorSwitch : MonoBehaviour {
	public GameObject door;
	public float initialPos;
	public float finalPos;
	// Use this for initialization
	void Start () {
		initialPos = transform.position.y;
		finalPos = transform.position.y - 0.4f;
	}
	

	void OnTriggerStay(Collider other) {
		if (other.gameObject.name != "Platform") {
			door.GetComponent<Door>().Activate ();
			transform.position = new Vector3(transform.position.x, finalPos, transform.position.z);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.name != "Platform") {
			door.GetComponent<Door>().Deactivate ();
			transform.position = new Vector3(transform.position.x, initialPos, transform.position.z);
		}
	}
}
