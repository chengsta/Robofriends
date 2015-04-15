using UnityEngine;
using System.Collections;

public class ExitStage : MonoBehaviour {
	public string next_level;

	// Use this for initialization
	void Start () {
		StartCoroutine("Exit_Time");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Exit_Time() {
		yield return new WaitForSeconds(3f);

		Application.LoadLevel(next_level);
	}
}
