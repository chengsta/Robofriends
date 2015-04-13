using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spikes : MonoBehaviour {
	public AudioClip LavaDeathSound;
	void playSound(AudioClip sound, float vol){
		GetComponent<AudioSource>().clip = sound;
		GetComponent<AudioSource>().volume = vol;
		GetComponent<AudioSource>().Play();
	}
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
			GetComponent<AudioSource>().PlayOneShot(LavaDeathSound, 1.0f);
			mainCamera.GetComponent<Manager>().FailState();
		}
		else if (r = coll.gameObject.GetComponent<Robot>()) {
			r.hitBySpikes();
			GameObject.Find("Player").GetComponent<Player>().FailState();
		}
		
	}
}
