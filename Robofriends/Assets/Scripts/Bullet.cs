using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("timer");
	}

	void OnTriggerEnter() {
		print ("Bullet hit something");
		Destroy (this.gameObject);
	}

	IEnumerator timer () {
		yield return new WaitForSeconds(2f);
		Destroy (this.gameObject);
	}
}
