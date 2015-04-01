using UnityEngine;
using System.Collections;

public class RisingLava : MonoBehaviour {
	public float speed;


	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate() {
		transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
