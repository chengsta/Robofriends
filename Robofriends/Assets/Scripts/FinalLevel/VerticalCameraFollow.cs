using UnityEngine;
using System.Collections;

public class VerticalCameraFollow : MonoBehaviour {
	public Transform player;
	public Transform Bottom;
	public Transform Top;

	private float bottomHeight;
	private float topHeight;

	// Use this for initialization
	void Start () {
		bottomHeight = Bottom.position.y;
		topHeight = Top.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.position.y <= bottomHeight) {
			transform.position = new Vector3(transform.position.x, bottomHeight, transform.position.z);
		}
		else if (player.position.y >= topHeight) {
			transform.position = new Vector3(transform.position.x, topHeight, transform.position.z);
		}
		else {
			transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
		}
	}
}
