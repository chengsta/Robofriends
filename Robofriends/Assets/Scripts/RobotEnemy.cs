using UnityEngine;
using System.Collections;

public class RobotEnemy : Robot {
	public bool activated;
	public float timer = 0;
	public GameObject bullet; 
	
	// Update is called once per frame
	void FixedUpdate () {
		if (activated) {
			if (timer == 0) {
				//TODO: bullet shoots in right direction
				GameObject go = Instantiate (bullet, this.transform.position, Quaternion.identity) as GameObject;
				go.rigidbody.AddForce (Vector3.right * 200);
			
				timer += Time.fixedDeltaTime;
			}
			else {
				//reset every 1 seconds
				timer += Time.fixedDeltaTime;
				if (timer >= 1) timer = 0;
			}

		}
		else {
			if (timer != 0) timer = 0;
		}
	}

}
