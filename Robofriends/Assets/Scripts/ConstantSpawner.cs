using UnityEngine;
using System.Collections;

public class ConstantSpawner : MonoBehaviour {
	public float spawnTimer;
	public float waitTime;
	public GameObject ObjectToSpawn;
	private GameObject go;
	public float timer;

	IEnumerator Spawn() {
		while (timer >= 0) {
			timer -= Time.deltaTime;
			yield return null;
		}
		while (go) {
			yield return null;
		}
		yield return new WaitForSeconds(waitTime);
		go = Instantiate(ObjectToSpawn, transform.position, Quaternion.identity) as GameObject;


		timer = spawnTimer;
		StartCoroutine("Spawn");

	}

	// Use this for initialization
	void Start () {
		timer = spawnTimer;
		StartCoroutine("Spawn");
		go = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
