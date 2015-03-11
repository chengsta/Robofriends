using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Cancel")) {
			Application.LoadLevel("Main_menu");
		}
		else if (Input.GetButtonDown("Restart")) {
			Application.LoadLevel(Application.loadedLevel);
		}
	
	}
}
