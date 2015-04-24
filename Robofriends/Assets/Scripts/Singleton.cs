using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour {
	public static Singleton instance = null;
	public static Singleton Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null) {
			Singleton temp = instance;
			instance = this;
			Destroy(temp.gameObject);
		} 

		else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
