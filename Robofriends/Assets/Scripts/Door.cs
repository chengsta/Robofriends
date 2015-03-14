using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public bool open;
	public int DistanceToMove = 5;
	private float finalPosition;
	private float initialPosition;
	public float timer;
	private bool opened;
	private int count;
	// Use this for initialization
	void Start () {
		initialPosition = transform.position.y;
		finalPosition = transform.position.y + DistanceToMove;
	}
	
	// Update is called once per frame
	void Update () {
		if (open && !opened) {
			//transform.position = new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z);
			transform.position = transform.position + transform.up;
			count++;
		}
		if (!open && opened) {
			//transform.position = new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z);
			transform.position = transform.position - transform.up;
			count++;
		}
		if (count == DistanceToMove) {
			opened = !opened;
			count = 0;
		}
	}
}
