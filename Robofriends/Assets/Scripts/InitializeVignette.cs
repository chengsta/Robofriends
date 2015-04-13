using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InitializeVignette : MonoBehaviour {

	void Awake() {
		Transform vignette = transform.FindChild("Vignette");
		vignette.gameObject.SetActive(true);
		vignette.GetComponent<Image>().CrossFadeAlpha(0, .00001f, true);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
