using UnityEngine;
using System.Collections;

public class RobotEnemy : Robot {
	public bool activated;
	public float timer = 0;
	public GameObject bullet;

	void Update () {

	}
	
	void FixedUpdate () {
		if (activated) {
			if (timer == 0) {
				//TODO: bullet shoots in right direction

				Vector3 bullet_start = this.transform.position;
				bullet_start.x += 1.5f;

				GameObject go = Instantiate (bullet, bullet_start, Quaternion.identity) as GameObject;
				go.rigidbody.AddForce (Vector3.right * 750);
			
				timer += Time.fixedDeltaTime;
			}
			else {
				//reset every 1 seconds
				timer += Time.fixedDeltaTime;
				if (timer >= 0.6) timer = 0;
			}

		}
		else {
			if (timer != 0) timer = 0;
		}
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.GetComponent<Bullet>()) {
			Destroy (this.gameObject);
		}
	}

}
