using UnityEngine;
using System.Collections;

public class PlayerLockGun : MonoBehaviour {
	public float timescale;
	private Robot lockedRobot;

	// Use this for initialization
	void Start () {
	
	}

	IEnumerator fireGun() {
		Vector3 clickPos;
		Vector3 direction;
		while (Input.GetButton("Fire1")) {
			clickPos =  UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
			clickPos.z = 0;
			GetComponent<LineRenderer>().SetPosition(0, transform.position);
			GetComponent<LineRenderer>().SetPosition(1, clickPos);
			yield return null;
		}

		GetComponent<LineRenderer>().SetPosition(0, Vector3.zero);
		GetComponent<LineRenderer>().SetPosition(1, Vector3.zero);

		Time.timeScale = 1.0f;
		clickPos =  UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);

		direction = clickPos - transform.position;
		direction.z = 0;
		direction.Normalize();
		
		RaycastHit hit = new RaycastHit();
		int layerMask = LayerMask.GetMask("Platform", "Robot");
		if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity, layerMask)) {
			Robot r;
			if (r = hit.collider.gameObject.GetComponent<Robot>()) {
				if (lockedRobot) {
					lockedRobot.ReleaseParent();
				}
				r.SetParent(gameObject);
				lockedRobot = r;
			}
		}
	}
	

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Time.timeScale = timescale;
			StartCoroutine("fireGun");
		}
		else if (Input.GetButtonDown("Fire2")) {
			if (lockedRobot) {
				lockedRobot.ReleaseParent();
				lockedRobot = null;
			}
		}


	}
}
