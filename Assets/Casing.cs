using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().AddForce(transform.up*50);

	}

 
void Update(){
 
}

}
