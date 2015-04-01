using UnityEngine;
using System.Collections;

public class LavaTrigger : MonoBehaviour {
	public Transform risingLava;
	public float jumpToPos;

	void OnTriggerEnter(Collider coll) {
		print ("hi");
		risingLava.position = new Vector3(risingLava.position.x, jumpToPos, risingLava.position.z);
		gameObject.SetActive(false);
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
