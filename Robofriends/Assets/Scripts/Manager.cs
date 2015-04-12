using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager : MonoBehaviour {

	void Awake() {

	}
	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetButtonDown("Cancel")) {
//			Application.LoadLevel("Main_menu");
//		}
//		else if (Input.GetButtonDown("Restart")) {
//			Application.LoadLevel(Application.loadedLevel);
//		}

		if (Input.GetButtonDown("Restart")) {
			Application.LoadLevel(Application.loadedLevel);
		}
	
	}
}
