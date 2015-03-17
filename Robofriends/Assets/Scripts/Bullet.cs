using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("timer");
	}

	void OnTriggerEnter(Collider coll) {
		print ("Bullet hit something");

		if (coll.GetComponent<RobotEnemy>()) {
			//is there a better way to do this?
			GameObject.Find("Player").GetComponent<PlayerLockGun>().ReleaseRobot();
			Destroy(coll.gameObject);
		}

		if (coll.GetComponent<Player>()) {
			Destroy(coll.gameObject);
		}

		Destroy (this.gameObject);
	}

	IEnumerator timer () {
		yield return new WaitForSeconds(2f);
		Destroy (this.gameObject);
	}
}
