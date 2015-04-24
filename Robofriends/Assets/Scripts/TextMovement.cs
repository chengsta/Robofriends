using UnityEngine;
using System.Collections;

public class TextMovement : MonoBehaviour {

	public Vector3 velocity;
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity = velocity;
	}
}
