using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("timer");
	}

	void OnTriggerEnter(Collider coll) {
		print ("Bullet hit something");

		if (coll.GetComponent<Player>() || coll.GetComponent<RobotEnemy>()) {
			Destroy(coll.gameObject);
		}

		Destroy (this.gameObject);
	}

	IEnumerator timer () {
		yield return new WaitForSeconds(2f);
		Destroy (this.gameObject);
	}
}
