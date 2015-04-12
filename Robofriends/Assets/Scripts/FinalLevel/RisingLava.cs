using UnityEngine;
using System.Collections;

public class RisingLava : MonoBehaviour {
	public float speed;


	// Use this for initialization
	void Start () {
	}

	void FixedUpdate() {
		float dy = speed * Time.deltaTime;
		transform.position = new Vector3(transform.position.x, transform.position.y + dy, transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
