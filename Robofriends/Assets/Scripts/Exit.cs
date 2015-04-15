using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Exit : TeleportPopup {
	public string nextLevel;

	public void Update() {
		if (Input.GetButtonDown("Skip")) {
			Activate();
		}
	}


	public override void Activate() {
		Image death = GameObject.FindGameObjectWithTag("Death").GetComponent<Image>();
		death.CrossFadeAlpha(1, 0.4f, true);
		StartCoroutine("loadNext");
	}

	IEnumerator loadNext() {
		yield return new WaitForSeconds(.4f);
		Application.LoadLevel (nextLevel);
	}

	
}
