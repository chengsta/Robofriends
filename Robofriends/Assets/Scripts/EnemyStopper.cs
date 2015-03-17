using UnityEngine;
using System.Collections;

public class EnemyStopper : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll) {
		RobotEnemy re;

		if (re = coll.GetComponent<RobotEnemy>()) {
			print ("stopper hit");
			Vector3 temp = coll.rigidbody.velocity;
			temp.x *= -1;
			re.facing_left = !re.facing_left;
			coll.rigidbody.velocity = temp;
		}
	}
}
