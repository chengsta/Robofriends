using UnityEngine;
using System.Collections;

public class TeleportPopup : MonoBehaviour {

	public static float teleportAnimTime = .3f;
	public static float teleportAnimHeight = 2;
	public Color TeleportColorStart;
	public Color TeleportColorEnd;
	
	public AudioClip EndLevel;
	private bool playedSound = false;
	void playSound(AudioClip sound, float vol){
		GetComponent<AudioSource>().clip = sound;
		GetComponent<AudioSource>().volume = vol;
		GetComponent<AudioSource>().Play();
	}

	private Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void OnTriggerEnter(Collider coll) {
		coll.transform.FindChild("ActionPopup").gameObject.SetActive(true);
		player = coll.transform;
		StartCoroutine("CheckActivated");


	}

	public virtual void OnTriggerExit(Collider coll) {
		coll.transform.FindChild("ActionPopup").gameObject.SetActive(false);
		StopCoroutine("CheckActivated");

	}

	IEnumerator CheckActivated() {
		while (!Input.GetButtonDown("Action")) {
			yield return null;
		}

		player.FindChild("ActionPopup").gameObject.SetActive(false);
		StartCoroutine("AnimateTeleportHelp");
	}


	IEnumerator AnimateTeleportHelp() {
		float TeleportTimer = teleportAnimTime;
		Vector3 startScale = new Vector3(1, 1, 1);
		Vector3 endScale = new Vector3(0, 1, 1);
		Vector3 startPos = new Vector3(player.position.x, player.position.y, player.position.z);
		Vector3 endPos = new Vector3(startPos.x, startPos.y + teleportAnimHeight, startPos.z);
		if (!playedSound) {
			playSound(EndLevel, 1.0f);
			playedSound = true;
		}
		player.GetComponent<Player>().enabled = false;
		//player.FindChild("Beam").gameObject.SetActive(true);
		
		while (TeleportTimer > 0) {
			float lerpPercent = 1 - (TeleportTimer / teleportAnimTime);
			lerpPercent = lerpPercent * lerpPercent * lerpPercent;
			
			Color newColor = Color.Lerp(TeleportColorStart, TeleportColorEnd, lerpPercent);
			player.FindChild("Beam").GetComponent<Renderer>().material.color = newColor;
			
			Vector3 newScale = Vector3.Lerp(startScale, endScale, lerpPercent);
			player.localScale = newScale;
			
			Vector3 newPos = Vector3.Lerp(startPos, endPos, lerpPercent);
			player.position = newPos;
			
			TeleportTimer -= Time.deltaTime;
			yield return null;
		}

		Destroy(player.gameObject);
		yield return new WaitForSeconds(.5f);

		Activate();
	}

	public virtual void Activate() {}
}
