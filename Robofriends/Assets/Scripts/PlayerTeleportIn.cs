using UnityEngine;
using System.Collections;

public class PlayerTeleportIn : MonoBehaviour {
	public static float teleportAnimTime = .3f;
	public static float teleportAnimHeight = 2;
	public Color TeleportColorStart;
	public Color TeleportColorEnd;

	Vector3 startScale;
	Vector3 endScale;
	Vector3 endPos;
	Vector3 startPos;
	

	// Use this for initialization
	void Start () {

		startScale = new Vector3(0, 1, 1);
		endScale = new Vector3(1, 1, 1);
		endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		startPos = new Vector3(endPos.x, endPos.y + teleportAnimHeight, endPos.z);

		gameObject.GetComponent<Player>().enabled = false;
		gameObject.GetComponent<PlayerLockGun>().enabled = false;
		transform.localScale = startScale;
		transform.position = startPos;
		StartCoroutine("AnimateTeleportHelp");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator AnimateTeleportHelp() {
		float TeleportTimer = teleportAnimTime;


		yield return new WaitForSeconds(.5f);
		//player.FindChild("Beam").gameObject.SetActive(true);
		
		while (TeleportTimer > 0) {
			float lerpPercent = 1 - (TeleportTimer / teleportAnimTime);
			lerpPercent = lerpPercent * lerpPercent * lerpPercent;
			
			//Color newColor = Color.Lerp(TeleportColorStart, TeleportColorEnd, lerpPercent);
			//player.FindChild("Beam").GetComponent<Renderer>().material.color = newColor;
			
			Vector3 newScale = Vector3.Lerp(startScale, endScale, lerpPercent);
			transform.localScale = newScale;
			
			Vector3 newPos = Vector3.Lerp(startPos, endPos, lerpPercent);
			transform.position = newPos;
			
			TeleportTimer -= Time.deltaTime;
			yield return null;
		}


		
		gameObject.GetComponent<Player>().enabled = true;
		gameObject.GetComponent<PlayerLockGun>().enabled = true;
	}
}
