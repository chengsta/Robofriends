using UnityEngine;
using System.Collections;

public class RobotGrav : Robot {
	public float up_force;
	public float max_speed;

	// Use this for initialization
	void Start () {
		if (tempAnimEnabled) {
			anim = this.GetComponentInChildren<Animator>();
			anim.Play ("RobotDead");
			sprite = this.GetComponentInChildren<Transform>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator ReverseGrav () {
		while (true) {
//			print ("start of grav coroutine");
			Rigidbody rb = GetComponentInParent<Rigidbody>();

			rb.useGravity = false;
			if (rb.velocity.y < max_speed) {
				rb.AddForce(up_force * Vector3.up);
			}
			yield return null;
		}
	}

}
