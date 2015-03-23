using UnityEngine;
using System.Collections;

public class RobotEnemy : Robot {
	public bool activated = false;
	public bool controlled = false;
	public float timer = 0;
	public GameObject bullet;
	public bool facing_left;

	void Start () {
		GetComponent<Collider>().material = frictionless;
		GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 0);
		StartCoroutine("scan");
	}

	IEnumerator scan () {
		while (true) {
			RaycastHit hit = new RaycastHit();
			int layerMask = LayerMask.GetMask("Player");

			Vector3 raycast_direction;

			if (facing_left) {
				raycast_direction = Vector3.left;
			}
			else {
				raycast_direction = Vector3.right;
			}

			if (Physics.Raycast (this.transform.position, raycast_direction, out hit, Mathf.Infinity, layerMask)) {
				activated = true;
			}

			else {
				activated = false;
			}

			yield return null;
		}
	}
	
	void FixedUpdate () {
		if (controlled || activated) {
			if (timer == 0) {
				//TODO: bullet shoots in right direction

				Vector3 bullet_start = this.transform.position;
				if (facing_left) {
					bullet_start.x -= 1.5f;
				}
				else {
					bullet_start.x += 1.5f;
				}

				GameObject go = Instantiate (bullet, bullet_start, Quaternion.identity) as GameObject;

				if (facing_left) {
					go.GetComponent<Rigidbody>().AddForce (Vector3.left * 750);
				}
				else {
					go.GetComponent<Rigidbody>().AddForce (Vector3.right * 750);
				}
			
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
}
