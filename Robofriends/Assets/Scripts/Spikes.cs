using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll) {
		Robot r;
		if (coll.gameObject.GetComponent<Player>()) {
			Application.LoadLevel (Application.loadedLevel);
		}
		else if (r = coll.gameObject.GetComponent<Robot>()) {
			r.hitBySpikes();
		}
		
	}
}
