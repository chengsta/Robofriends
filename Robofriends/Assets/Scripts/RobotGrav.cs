using UnityEngine;
using System.Collections;

public class RobotGrav : Robot {
	public float up_force;

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
			GetComponentInParent<Rigidbody>().useGravity = false;
			GetComponentInParent<Rigidbody>().AddForce(up_force * Vector3.up);
			yield return null;
		}
	}

}
