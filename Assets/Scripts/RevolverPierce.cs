using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverPierce : MonoBehaviour {
	public int piercenum=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(piercenum==5){
			Destroy(gameObject);
		}
		
	}
 void LateUpdate()
	{
		Shoot();
	}
	 void Shoot()
 {
 RaycastHit2D[] hits;
 
  hits = Physics2D.RaycastAll(transform.position,transform.right,1f);
 
 foreach(RaycastHit2D hit in hits )
 {
	 piercenum++;
	Debug.DrawRay(transform.position,transform.right,Color.red,0.5f);
  if(hit.transform.tag=="Enemy")
  {
	  if(piercenum==5){
		  Destroy(gameObject);
	  }
  hit.rigidbody.GetComponent<Health>().HP-=GameObject.Find("Pistol").GetComponent<PlatShootSemi>().Damage;
  
  }
 }
 
 }
}
