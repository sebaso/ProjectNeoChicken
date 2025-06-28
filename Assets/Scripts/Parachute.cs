using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute : MonoBehaviour {

[SerializeField]
private float speed=10f;
public GameObject Player;
public Transform playerpos;
public GameObject bullet;
public Vector3 vel;
public GameObject grunt;
public bool canfire=false;
public int MinDist =5;
private Rigidbody2D rb;
[SerializeField]
private bool canshoot=true;
[SerializeField]

private Vector3 target;
[SerializeField]
private float vel_limit;


	void Start () {
		playerpos=GameObject.Find("Player").transform;
		Player=GameObject.FindGameObjectWithTag("Player");
		rb=GetComponent<Rigidbody2D>();
	


		
	}
	
	// Update is called once per frame
	void Update () {
		AttackTimer();
		          if(Vector2.Distance(transform.position,Player.transform.position) <= MinDist+1)
              {
				   		if(canshoot==true){
		canshoot=false; 
        GameObject firedbullet =Instantiate(bullet,	new Vector2(transform.position.x,transform.position.y),Quaternion.Euler(0,0,0));
		firedbullet.transform.position= Vector2.MoveTowards(firedbullet.transform.position,GameObject.Find("Player").gameObject.transform.position,speed*Time.deltaTime);
		firedbullet.GetComponent<Rigidbody2D>().linearVelocity = (GameObject.Find("Player").transform.position - transform.position).normalized * speed;
		canshoot=false;
		timer=5;
    }
		

 }
	}
		


	
		

		
	



	

	void OnCollisionEnter2D(Collision2D other)
	{
		vel=rb.linearVelocity;

		if(other.gameObject.layer==8){
					if(rb.linearVelocity.x>vel_limit||rb.linearVelocity.y>vel_limit){	
			Destroy(gameObject);
					}
			else{
			Instantiate(grunt,transform.position,transform.rotation);
			Destroy(gameObject);
			}

		}

		

		
		
	}	
	[SerializeField]
			 private float timer = 5f;
 private void AttackTimer()
 {
     timer -= Time.deltaTime;
     if (timer < 0)
     {
canshoot=true;

     }

}
void Fire(){
			
 		if(canshoot==true){
			 canshoot=false; 
				
		GameObject firedbullet =Instantiate(bullet,	new Vector2(transform.position.x,transform.position.y-0.3f),Quaternion.Euler(0,0,0));
		firedbullet.transform.position= Vector2.MoveTowards(firedbullet.transform.position,GameObject.Find("Player").gameObject.transform.position,speed*Time.deltaTime);
		firedbullet.GetComponent<Rigidbody2D>().linearVelocity = (GameObject.Find("Player").transform.position - transform.position).normalized * speed;
		canshoot=false;
		timer=5;
}
}
}

		

	
	

