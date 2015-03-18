using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public bool default_closed = true;

	public bool open;
	public int DistanceToMove = 5;
	private float finalPosition;
	private float initialPosition;
	public float timer;
	private bool opened;
	private int count;
	// Use this for initialization
	void Start () {
		initialPosition = transform.position.y;
		finalPosition = transform.position.y + DistanceToMove;
	}
	
	// Update is called once per frame
	void Update () {
		//Currently we will use the appear/disappear method




		if (open && !opened) {
			//transform.position = new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z);
			transform.position = transform.position + transform.up;
			count++;
		}
		if (!open && opened) {
			//transform.position = new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z);
			transform.position = transform.position - transform.up;
			count++;
		}
		if (count == DistanceToMove) {
			opened = !opened;
			count = 0;
		}
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
