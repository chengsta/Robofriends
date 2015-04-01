using UnityEngine;
using System.Collections;

public class Exit : TeleportPopup {
	public string nextLevel;

	public override void Activate() {
		Application.LoadLevel (nextLevel);
	}
	
}
