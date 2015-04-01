using UnityEngine;
using System.Collections;

public class Entrance : TeleportPopup {
	public int LevelID;
	public int TurnOnAfterLevel;
	public string levelName;

	// Use this for initialization
	void Start () {
		if (LevelManager.IsLevelFinished(TurnOnAfterLevel)) {
			if (LevelManager.IsLevelFinished(LevelID)) {
				transform.FindChild("TeleporterOn").gameObject.SetActive(false);
			}
			else {
				transform.FindChild("TeleporterFinished").gameObject.SetActive(false);
			}
		}
		else {
			transform.FindChild("TeleporterOn").gameObject.SetActive(false);
			transform.FindChild("TeleporterFinished").gameObject.SetActive(false);
		}
	}

	public override void Activate() {
		
		Application.LoadLevel (levelName);
		LevelManager.LastLevelVisited = LevelID;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
