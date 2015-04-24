using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour {
	public float fadeTime;

	private AudioSource audiosource;

	public static Singleton instance = null;
	public static Singleton Instance {
		get { return instance; }
	}
	void Awake() {
		audiosource = this.gameObject.GetComponent<AudioSource>();
		if (instance != null) {
			Singleton temp = instance;
			instance = this;
			//Destroy(temp.gameObject);
			temp.Die();
		} 

		else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);

		audiosource.volume = 0;
		StartCoroutine("fadeIn");
	}


	IEnumerator fadeIn() {
		float timer = 0;

		while (timer < fadeTime) {
			audiosource.volume = timer / fadeTime;
			timer += Time.deltaTime;
			yield return null;
		}

		audiosource.volume = 1;
	}

	IEnumerator fadeOut() {
		float timer = 0;
		
		while (timer < fadeTime) {
			audiosource.volume = 1 -  timer / fadeTime;
			timer += Time.deltaTime;
			yield return null;
		}
		
		audiosource.volume = 0;
		Destroy(this.gameObject);
	}

	public void Die() {
		StartCoroutine("fadeOut");
	}
}



