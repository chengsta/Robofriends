using UnityEngine;
using System.Collections;

public class ResetManager : Manager {
	public string nextLevel;

	// Use this for initialization
	
	// Update is called once per frame
	public override void Update () {
		if (Input.GetButtonDown("Restart")) {
			death.CrossFadeAlpha(1, 0.4f, true);
			StartCoroutine("loadNext");
		}
	}


	public IEnumerator loadNext() {
		//player.GetComponent<Player>().enabled = false;
		player.GetComponent<PlayerLockGun>().enabled = false;
		yield return new WaitForSeconds(.3f);
		Application.LoadLevel (nextLevel);
	}
}
