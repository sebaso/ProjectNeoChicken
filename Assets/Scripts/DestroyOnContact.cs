using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {
	public LayerMask Ground;
	public Collider2D col;
	Transform PE;


	void Start()
	{
		col= GetComponent<Collider2D>();

	}



	void Update () {
		if (Physics2D.IsTouchingLayers(col,Ground)){
			Destroy(gameObject);
		}
		

		
	}
}
