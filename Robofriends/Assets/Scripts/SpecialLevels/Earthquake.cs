using UnityEngine;
using System.Collections;

public class Earthquake : MonoBehaviour {
	public GameObject text;

	public float maxShakeDistance;
	public float shakeSpeed;
	public int shakeTime;
	public Camera cam;

	public GameObject end;
	
	public float amountToMove;
	public float lerpTime;

	private bool first = false;
	private Vector3 endPos;
	private Vector3 beginPos;
	
	// Use this for initialization
	void Start () {
		endPos = end.transform.position;
		beginPos = endPos;
		beginPos.y -= amountToMove;
		
		end.transform.position = beginPos;

		text.SetActive(false);

	}
	
	
	IEnumerator activateTeleport() {
		
		float timer = 0;
		while (timer < lerpTime) {
			
			Vector3 newPos =  Vector3.Lerp(endPos, beginPos, (lerpTime - timer)/lerpTime);
			end.transform.position = newPos;
			yield return null;
			timer += Time.deltaTime;
		}
		
		end.transform.position = endPos;
	}

	void OnTriggerEnter (Collider coll) {
		if (!first) {
			first = true;
			Transform to = transform.GetChild(0);
			Destroy(to.gameObject);
			StartCoroutine ("EarthquakeStart");
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator EarthquakeStart() {
		float originalPosition = cam.transform.localPosition.x;
		float timer = 0;

		while (timer < shakeTime) {
			float ratio = timer / shakeTime;

			float shakeDistance = maxShakeDistance * ratio;

			Vector3 lastPos = cam.transform.localPosition;
			lastPos.x = originalPosition + Mathf.Sin (timer * shakeSpeed) * Random.Range(0, shakeDistance);
			cam.transform.localPosition = lastPos;

			timer += Time.deltaTime;
			yield return null;
		}

		while (timer > 0) {
			float ratio = timer / shakeTime;
			
			float shakeDistance = maxShakeDistance * ratio;
			
			Vector3 lastPos = cam.transform.localPosition;
			lastPos.x = originalPosition + Mathf.Sin (timer * shakeSpeed) * Random.Range(0, shakeDistance);
			cam.transform.localPosition = lastPos;
			
			timer -= Time.deltaTime;
			yield return null;
		}

		StartCoroutine("activateTeleport");
		text.SetActive(true);
	}
}
