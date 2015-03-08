using UnityEngine;
using System.Collections;

public class RobotJump : Robot {
	private GroundChecker groundChecker;

	// Use this for initialization
	void Start () {
		groundChecker  = GetComponent<GroundChecker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override bool CanJump() {
		return groundChecker.IsGrounded();
	}
}
