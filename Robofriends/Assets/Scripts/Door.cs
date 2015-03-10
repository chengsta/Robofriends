using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public bool open;
	public float finalPosition;
	public float initialPosition;
	public float timer;
	// Use this for initialization
	void Start () {
		initialPosition = transform.position.y;
		finalPosition = transform.position.y + 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (open && transform.position.y < finalPosition) {
			transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
		}
		if (!open && transform.position.y > initialPosition) {
			transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
		}
	}
}
