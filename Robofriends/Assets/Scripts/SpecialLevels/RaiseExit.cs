using UnityEngine;
using System.Collections;

public class RaiseExit : MonoBehaviour {
	public GameObject end;

	public float amountToMove;
	public float lerpTime;
	
	private Vector3 endPos;
	private Vector3 beginPos;
	
	// Use this for initialization
	void Start () {
		endPos = end.transform.position;
		beginPos = endPos;
		beginPos.y -= amountToMove;
		
		end.transform.position = beginPos;
		
		StartCoroutine("activateTeleport");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	IEnumerator activateTeleport() {

		yield return new WaitForSeconds(7.5f);
		
		float timer = 0;
		while (timer < lerpTime) {
			
			Vector3 newPos =  Vector3.Lerp(endPos, beginPos, (lerpTime - timer)/lerpTime);
			end.transform.position = newPos;
			yield return null;
			timer += Time.deltaTime;
		}

		end.transform.position = endPos;
	}
}
