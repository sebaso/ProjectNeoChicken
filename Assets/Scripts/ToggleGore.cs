using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleGore : MonoBehaviour {
	public Toggle goretoggle;
	public bool wastoggled;
	public bool done;


	// Use this for initialization
	void Start () {
	
		if(PlayerPrefs.GetInt("Gore")==0){
			goretoggle.isOn=false;
			
			
			

		}
				
		if(PlayerPrefs.GetInt("Gore")==1){
		
			goretoggle.isOn=true;
			
			

		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Gore(bool toggled){




		
		if(toggled==false){
		PlayerPrefs.SetInt("Gore",0);
		}
		if(toggled==true){
		PlayerPrefs.SetInt("Gore",1);
		}
		Debug.Log(toggled);
	}
}
