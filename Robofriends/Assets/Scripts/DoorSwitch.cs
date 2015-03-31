using UnityEngine;
using System.Collections;

public class DoorSwitch : MonoBehaviour {
	public GameObject door;
	public float initialPos;
	public float finalPos;

	private Transform sprite;

	// Use this for initialization
	void Start () {
		initialPos = transform.position.y;
		finalPos = transform.position.y - 0.2f;
		sprite = transform.FindChild("Sprite");
	}
	

	void OnTriggerStay(Collider other) {
		if (other.gameObject.name != "Platform") {
			door.GetComponent<Door>().Activate ();
			sprite.position = new Vector3(sprite.position.x, finalPos, sprite.position.z);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.name != "Platform") {
			door.GetComponent<Door>().Deactivate ();
			sprite.position = new Vector3(sprite.position.x, initialPos, sprite.position.z);
		}
	}
}
