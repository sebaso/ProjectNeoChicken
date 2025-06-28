using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour {

public GameObject Gun;
	public float Damage;
	

	void Start () {


		

	}
	
	// Update is called once per frame
	void Update () {


		

	
	}


		void OnCollisionEnter2D(Collision2D other)
		{
			if(other.gameObject.layer!=14){
			Destroy(gameObject);
		}
		}
		
	


    
		
  } 
	


