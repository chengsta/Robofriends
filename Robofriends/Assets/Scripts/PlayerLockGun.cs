using UnityEngine;
using System.Collections;
using VolumetricLines;
using UnityEngine.UI;

public class PlayerLockGun : MonoBehaviour {
	public float slowdown;
	private Robot lockedRobot;
	public float maxShootDistance;
	public float shootTime;
	public float vignetteFadeTime;
	public AudioClip GunSound;

	public Material normal_Material;
	public Material hit_Material;

	void playSound(AudioClip sound, float vol){
		GetComponent<AudioSource>().clip = sound;
		GetComponent<AudioSource>().volume = vol;
		GetComponent<AudioSource>().Play();
	}
	//for gravity flipping
	private IEnumerator gravCoroutine;

	//private LineRenderer connection;
	private VolumetricLineBehavior volConnection;

	private Image vignette;


	// Use this for initialization
	void Start () {
		//connection = transform.FindChild("Gun").GetComponentInChildren<LineRenderer>();
		volConnection = transform.FindChild("Connector").GetComponent<VolumetricLineBehavior>();

		vignette = GameObject.FindGameObjectWithTag("Vignette").GetComponent<Image>();

	}

	IEnumerator fireGun() {
		Vector3 clickPos;
		Vector3 direction;
		int layerMask = LayerMask.GetMask("Platform", "Robot");
		int robotMask = LayerMask.GetMask ("Robot");
		RaycastHit hit = new RaycastHit();

		vignette.CrossFadeAlpha(1, vignetteFadeTime * 3, true);

		while (Input.GetButton("Fire1")) {
			GetComponent<LineRenderer>().material = normal_Material;
			clickPos =  UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
			clickPos.z = 0;

			Vector3 lineEndpoint = new Vector3();
			direction = clickPos - transform.position;

			if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity, layerMask)) {
				lineEndpoint = hit.point;
			}
			else {
				direction.Normalize();
				lineEndpoint = transform.position + (direction * maxShootDistance);
			}

			GetComponent<LineRenderer>().SetPosition(0, transform.position);
			GetComponent<LineRenderer>().SetPosition(1, lineEndpoint);

			if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity, robotMask)) {
				GetComponent<LineRenderer>().material = hit_Material;
			}

			yield return null;
		}

		vignette.CrossFadeAlpha(0, vignetteFadeTime, true);

		GetComponent<LineRenderer>().SetPosition(0, Vector3.zero);
		GetComponent<LineRenderer>().SetPosition(1, Vector3.zero);

		Time.timeScale = 1.0f;
		Time.fixedDeltaTime = Time.fixedDeltaTime * slowdown;
		clickPos =  UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);

		direction = clickPos - transform.position;
		direction.z = 0;
		direction.Normalize();

		if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity, layerMask)) {
			Robot r = hit.collider.gameObject.GetComponent<Robot>();

			if (r != null && r != lockedRobot) {

				if (lockedRobot) {
					ReleaseRobot();
				}
				r.SetParent(gameObject);
				lockedRobot = r;

				//activate enemy bots
//				RobotEnemy robot_enemy;
//				if (robot_enemy = lockedRobot.GetComponent<RobotEnemy>()) {
//					robot_enemy.controlled = true;
//				}

				RobotGrav robot_grav;
				if (robot_grav = lockedRobot.GetComponent<RobotGrav>()) {
					gravCoroutine = robot_grav.ReverseGrav();
					StartCoroutine(gravCoroutine);
				}

				//connection.SetPosition(0, this.transform.position);
				//connection.SetPosition(1, r.transform.position);
				StartCoroutine("shootLine");
			}
		}
	}
	

	private bool swap = false;

	void FixedUpdate() {
		if (swap) {
			if (lockedRobot && lockedRobot.GetComponent<RobotSwap>()) {
				Vector3 currentLocation = this.transform.position;
				Vector3 robotLocation = lockedRobot.transform.position;
					
				this.transform.position = robotLocation;
				lockedRobot.transform.position = currentLocation;
					
				volConnection.m_endPos = volConnection.m_endPos * -1;
			}

			swap = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			LockRobot();
		}
		else if (Input.GetButtonDown("Fire2")) {
			ReleaseRobot ();
		}
		else if (Input.GetButtonDown ("Action")) {
			swap = true;
		}
	}

	IEnumerator shootLine() {
		float timer = shootTime;
		GetComponent<AudioSource>().PlayOneShot(GunSound, 1.0f);

		while (timer > 0) {
			float lerpPercent = 1 - (timer / shootTime);
			lerpPercent = lerpPercent * lerpPercent;

			volConnection.m_startPos = Vector3.zero;
			
			Vector3 endPos = Vector3.Lerp(Vector3.zero, lockedRobot.transform.localPosition, lerpPercent);
			volConnection.m_endPos = endPos;
			
			timer -= Time.deltaTime;
			yield return null;
		}

		volConnection.m_endPos = lockedRobot.transform.localPosition;
		StartCoroutine("drawLine");
	}

	IEnumerator drawLine() {
		while(lockedRobot) {
//			volConnection.m_endPos = lockedRobot.transform.position - transform.position;
//			volConnection.m_startPos = Vector3.zero;
//


			//connection.SetPosition(0, this.transform.position);
			//connection.SetPosition(1, lockedRobot.transform.position);
			yield return null;

			if (lockedRobot == null) {
					volConnection.m_startPos = Vector3.zero;
					volConnection.m_endPos = Vector3.zero;

				//connection.SetPosition (0, Vector3.zero);
				//connection.SetPosition (1, Vector3.zero);
			} 
		}
	}

	public void ReleaseRobot () {
		if (lockedRobot) {

			//check for enemy robot
//			RobotEnemy robot_enemy;
//			if (robot_enemy = lockedRobot.GetComponent<RobotEnemy>()) {
//				robot_enemy.controlled = false;
//			}

			RobotGrav robot_grav;
			if (robot_grav = lockedRobot.GetComponent<RobotGrav>()) {
				StopCoroutine(gravCoroutine);
			}

			lockedRobot.ReleaseParent();

			if (robot_grav) {
				this.GetComponent<Rigidbody>().useGravity = true;
				lockedRobot.GetComponent<Rigidbody>().useGravity = true;
			}

			lockedRobot = null;

			//remove connection line
			StopCoroutine("shootLine");
			StopCoroutine ("drawLine");
			//connection.SetPosition (0, Vector3.zero);
			//connection.SetPosition (1, Vector3.zero);

			volConnection.m_startPos = Vector3.zero;
			volConnection.m_endPos = Vector3.zero;
		}
	}
	public void LockRobot() {
		Time.timeScale = Time.timeScale / slowdown;
		Time.fixedDeltaTime = Time.fixedDeltaTime / slowdown;
		StartCoroutine("fireGun");

	}
}
