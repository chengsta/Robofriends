using UnityEngine;
using System.Collections;

public class RobotJump : Robot {
	private GroundChecker myGroundChecker;

	// Use this for initialization
	public virtual void Start () {
		myGroundChecker  = GetComponent<GroundChecker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override bool CanJump() {
		return myGroundChecker.IsGrounded();
	}
}
