using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
public static bool GamePaused=false;
public GameObject pausemenuui;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(GamePaused){
				Resume();
			}
			else
			{
				Pause();
			}
		}
		
	}
	public void Resume(){
		pausemenuui.SetActive(false);
		Time.timeScale=1f;
		GamePaused=false;

	}
	void Pause(){
		pausemenuui.SetActive(true);
		Time.timeScale=0f;
		GamePaused=true;

	}
	public void LoadMenu(){
		Time.timeScale=1f;
		SceneManager.LoadScene(0);

	}
	public void QuitGame(){
		Application.Quit();

	}
}
