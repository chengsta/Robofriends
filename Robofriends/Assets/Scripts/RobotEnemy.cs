using UnityEngine;
using System.Collections;

public class RobotEnemy : Robot {
	public bool activated;
	public GameObject bullet; 
	
	// Update is called once per frame
	void Update () {
		if (activated) {
			StartCoroutine("shoot");
			activated = false;
		}
	}

	IEnumerator shoot() {
		//TODO: Make sure bullet goes direction bot is facing
		GameObject go = Instantiate (bullet, this.transform.position, Quaternion.identity) as GameObject;
		go.rigidbody.AddForce(Vector3.right * 200);
		yield return new WaitForSeconds(3);
	}
}
