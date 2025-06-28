using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomforce : MonoBehaviour {
	public int speed =10;

	// Use this for initialization
	void Start () {
					 GetComponent<Rigidbody2D>().AddRelativeForce(Random.onUnitSphere * speed,ForceMode2D.Impulse);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
