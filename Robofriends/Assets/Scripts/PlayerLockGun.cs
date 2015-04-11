using UnityEngine;
using System.Collections;
using VolumetricLines;

public class PlayerLockGun : MonoBehaviour {
	public float slowdown;
	private Robot lockedRobot;
	public float maxShootDistance;
	public float shootTime;
	public AudioClip GunSound;
	void playSound(AudioClip sound, float vol){
		GetComponent<AudioSource>().clip = sound;
		GetComponent<AudioSource>().volume = vol;
		GetComponent<AudioSource>().Play();
	}
	//for gravity flipping
	private IEnumerator gravCoroutine;

	//private LineRenderer connection;
	private VolumetricLineBehavior volConnection;

	// Use this for initialization
	void Start () {
		//connection = transform.FindChild("Gun").GetComponentInChildren<LineRenderer>();
		volConnection = transform.FindChild("Connector").GetComponent<VolumetricLineBehavior>();
	}

	IEnumerator fireGun() {
		Vector3 clickPos;
		Vector3 direction;
		int layerMask = LayerMask.GetMask("Platform", "Robot");
		RaycastHit hit = new RaycastHit();

		while (Input.GetButton("Fire1")) {
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
			yield return null;
		}

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
	

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			LockRobot();
		}
		else if (Input.GetButtonDown("Fire2")) {
			ReleaseRobot ();
		}
		else if (Input.GetButtonDown ("Action")) {
			if (lockedRobot && lockedRobot.GetComponent<RobotSwap>()) {
				Vector3 currentLocation = this.transform.position;
				Vector3 robotLocation = lockedRobot.transform.position;

				this.transform.position = robotLocation;
				lockedRobot.transform.position = currentLocation;
			}
		}
	}

	IEnumerator shootLine() {
		float timer = shootTime;
		GetComponent<AudioSource>().PlayOneShot(GunSound, 1.0f);

		while (timer > 0) {
			float lerpPercent = 1 - (timer / shootTime);
			lerpPercent = lerpPercent * lerpPercent;

			volConnection.m_startPos = Vector3.zero;
			
			Vector3 endPos = Vector3.Lerp(Vector3.zero, lockedRobot.transform.position - transform.position, lerpPercent);
			volConnection.m_endPos = endPos;
			
			timer -= Time.deltaTime;
			yield return null;
		}

		StartCoroutine("drawLine");
	}

	IEnumerator drawLine() {
		while(lockedRobot) {
			volConnection.m_startPos = Vector3.zero;
			volConnection.m_endPos = lockedRobot.transform.position - transform.position;


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
