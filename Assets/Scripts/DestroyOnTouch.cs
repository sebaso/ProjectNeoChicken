﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	 void OnCollisionEnter ( )
 {
    GameObject.Destroy ( gameObject ) ;
 
 }
}
