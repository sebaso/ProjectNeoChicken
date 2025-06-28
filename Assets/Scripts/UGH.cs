using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGH : MonoBehaviour {

	// Use this for initialization
	public bool canJump;
	float x;
	private Rigidbody2D rb;

	void Start () {
		rb=GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		x=Input.GetAxisRaw("Horizontal");
		if(Input.GetKeyDown(KeyCode.Space) && canJump==true){
			rb.AddForce(Vector2.up*50, ForceMode2D.Impulse);
			canJump=false;
		}
		
	}

	void FixedUpdate()
	{
		rb.position+= Vector2.right*x*0.2f;
		if(rb.linearVelocity.y==0){
			canJump=true;
		}
	}
}
