using UnityEngine;
using System.Collections;

public class InitializeVignette : MonoBehaviour {

	void Awake() {
		Transform vignette = transform.FindChild("Vignette");
		vignette.gameObject.SetActive(true);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
