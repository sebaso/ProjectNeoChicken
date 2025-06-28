using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAI : MonoBehaviour {

	// Use this for initialization
	
AI triggered;
	void Start () {
		triggered=GetComponent<AI>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 void OnTriggerEnter2D(Collider2D other)
	 
		 
 {
 if(other.tag == "Player")
	 triggered.enabled=true;
	
 
 }

 void OnTriggerExit2D(Collider2D other)
 {
 if(other.tag == "Player") 
	 triggered.enabled=false;
 

}
}
