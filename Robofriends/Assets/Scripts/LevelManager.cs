using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {
	//private static LevelManager _instance;
	private static Object _lock = new Object();
	private static HashSet<int> completed_levels = new HashSet<int>();

//	public static LevelManager GetInstance() {
//		lock(_lock) {
//			if (_instance == null) {
//				_instance = new LevelManager();
//			}
//		}
//
//		return _instance;
//	}

	public static void FinishLevel(int levelID) {
		lock(_lock) {
			completed_levels.Add(levelID);
		}
	}

	public static bool IsLevelFinished(int levelID) {
		lock(_lock) {
			return completed_levels.Contains(levelID);
		}
	}


}
