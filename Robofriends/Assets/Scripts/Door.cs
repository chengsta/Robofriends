using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public bool open;
	public float DistanceToMove;
	private float finalPosition;
	private float initialPosition;
	public float timer;
	// Use this for initialization
	void Start () {
		initialPosition = transform.position.y;
		finalPosition = transform.position.y + DistanceToMove;
	}
	
	// Update is called once per frame
	void Update () {
		if (open && transform.position.y < finalPosition) {
			transform.position = new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z);
		}
		if (!open && transform.position.y > initialPosition) {
			transform.position = new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z);
		}
	}
}
