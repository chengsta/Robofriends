using UnityEngine;
using System.Collections;

public class RobotJump : Robot {
	private GroundChecker myGroundChecker;

	// Use this for initialization
	public virtual void Start () {
		myGroundChecker  = GetComponent<GroundChecker>();
		anim = this.GetComponentInChildren<Animator>();
		anim.Play ("RobotDead");
		sprite = this.GetComponentInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (connected) {
			Vector3 tmpScale = sprite.localScale;
			if (Input.GetAxis("Horizontal") < -0.1f) {
				tmpScale.x = -1;
			} else if (Input.GetAxis("Horizontal") > 0.1f) {
				tmpScale.x = 1;
			}
			sprite.localScale = tmpScale;
		}
		if (connected) {
			if (myGroundChecker.IsGrounded () && Mathf.Abs (Input.GetAxis ("Horizontal")) > 0.2f) {
				anim.Play ("RobotRoll");
			} else if (myGroundChecker.IsGrounded()) {
				anim.Play ("JumpGround");
			} else { 
				anim.Play ("RobotAir");
			}
		}
	}

	public override bool CanJump() {
		return myGroundChecker.IsGrounded();
	}
}
