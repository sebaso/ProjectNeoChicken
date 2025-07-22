using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{}


 public void ChangeScene(int sceneName) {
	 PauseMenu.GamePaused=false;
	  SceneManager.LoadScene(sceneName); }
		
	}
	
	// Update is called once per frame

	

