using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIPOutOfSight : MonoBehaviour {

	// Use this for initialization

	public bool Seen;
	void Start () {
		Seen=false;
		
	}

	void OnBecameVisible()
	{
	Seen=true;	
	}

	void OnBecameInvisible()
	{
		if(Seen==true){
		Destroy(gameObject);
		}


	}

}
