﻿using UnityEngine;
using System.Collections;

public class DC : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			coll.gameObject.GetComponent<PlayerLockGun>().ReleaseRobot();
		}
	}
}
