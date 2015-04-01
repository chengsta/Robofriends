using UnityEngine;
using System.Collections;

public class Exit : TeleportPopup {
	public string nextLevel;

	public void Update() {
		if (Input.GetButtonDown("Skip")) {
			Activate();
		}
	}


	public override void Activate() {
		Application.LoadLevel (nextLevel);
	}
	
}
