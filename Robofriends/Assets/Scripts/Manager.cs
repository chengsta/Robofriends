using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager : MonoBehaviour {

	public bool show_fail_state = false;
	public bool show_fade_in = true;
	
	protected Image death;
	public GameObject player;
	public IEnumerator dead(float waitTime) {
		//player.GetComponent<Player>().enabled = false;
		player.GetComponent<PlayerLockGun>().enabled = false;
		yield return new WaitForSeconds(waitTime);
		Application.LoadLevel (Application.loadedLevel);
	}

	public void Awake() {
	}
	// Use this for initialization
	public void Start () {
		if (show_fade_in) {
			Time.timeScale = 1f;
			death = GameObject.FindGameObjectWithTag("Death").GetComponent<Image>();
			player = GameObject.Find ("Player");
			death.CrossFadeAlpha(0, .5f, true);
		}
	}

	public void FailState () {
		death.CrossFadeAlpha(1, 0.5f, true);
		player.GetComponent<Player>().moveSpeed = 0;
		player.GetComponent<Player>().jumpSpeed = 0;
		StartCoroutine(dead(1.0f));
	}
	
	// Update is called once per frame
	public virtual void Update () {
//		if (Input.GetButtonDown("Cancel")) {
//			Application.LoadLevel("Main_menu");
//		}
//		else if (Input.GetButtonDown("Restart")) {
//			Application.LoadLevel(Application.loadedLevel);
//		}

		if (Input.GetButtonDown("Restart")) {
			death.CrossFadeAlpha(1, 0.4f, true);
			StartCoroutine(dead(.3f));
		}
	
	}
}
