using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public bool default_closed = true;

	public AudioClip DoorOpen;
	public AudioClip DoorClose;
	public bool audioPlaying;
	
	void playSound(AudioClip sound, float vol){
		GetComponent<AudioSource>().clip = sound;
		GetComponent<AudioSource>().volume = vol;
		GetComponent<AudioSource>().Play();
	}

	public bool open;
	public int DistanceToMove = 5;
	private float finalPosition;
	private float initialPosition;
	public float timer;
	public bool opened;
	private int count;
	// Use this for initialization
	void Start () {
		initialPosition = transform.position.y;
		finalPosition = transform.position.y + DistanceToMove;
	}
	
	// Update is called once per frame
	void Update () {
		//Currently we will use the appear/disappear method




		if (open && count < DistanceToMove) {
			//transform.position = new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z);
			transform.position = transform.position + transform.up;
			count++;
			if (GetComponent<AudioSource>().isPlaying && GetComponent<AudioSource>().clip == DoorClose) {
				GetComponent<AudioSource>().Stop();
			}
			if (!audioPlaying) {
				playSound (DoorOpen, 0.5f);
				audioPlaying = true;
			}
		}

		else if (!open && count > 0) {
			//transform.position = new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z);
			transform.position = transform.position - transform.up;
			count--;
			if (GetComponent<AudioSource>().isPlaying && GetComponent<AudioSource>().clip == DoorOpen) {
				GetComponent<AudioSource>().Stop();
			}
			if (!audioPlaying) {
				playSound (DoorClose, 0.5f);
				audioPlaying = true;
			}
		}
		else {
			audioPlaying = false;
		}
		//if (count == DistanceToMove || count == 0) {
		//	opened = !opened;
		//}
	}

	public void Activate() {
		if (default_closed)
			Open ();
		else
			Close ();
	}

	public void Deactivate() {
		if (default_closed)
			Close ();
		else
			Open ();
	}


	private void Open() {
		//gameObject.SetActive(false);
		open = true;
	}

	private void Close() {
		//gameObject.SetActive(true);
		open = false;
	}
 }
