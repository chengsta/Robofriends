using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spikes : MonoBehaviour {

	public GameObject mainCamera;
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider coll) {
		Robot r;
		if (coll.gameObject.GetComponent<Player>()) {
			//disable character's scripts here
			mainCamera.GetComponent<Manager>().FailState();
		}
		else if (r = coll.gameObject.GetComponent<Robot>()) {
			r.hitBySpikes();
		}
		
	}
}
