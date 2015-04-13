using UnityEngine;
using System.Collections;

public class InitializeDeath : MonoBehaviour {

	void Awake() {
		Transform death = transform.FindChild("Death");
		death.gameObject.SetActive(true);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
