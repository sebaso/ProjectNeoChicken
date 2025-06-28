using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	private Quaternion dir;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		  Vector2 dir = rb.linearVelocity;
  float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
  transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
		
	}
}
