using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	public float timer = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.fixedDeltaTime;
		if (timer > 1.0f && timer < 5.0f) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	void OnTriggerEnter(Collider coll) {
		Robot r;
		if (coll.gameObject.GetComponent<Player>()) {
			timer = 0;
			Time.timeScale = 0.001f;
		}
		else if (r = coll.gameObject.GetComponent<Robot>()) {
			r.hitBySpikes();
		}
		
	}
}
