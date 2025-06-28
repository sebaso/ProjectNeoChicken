using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butcher_AI : MonoBehaviour {

	 public GameObject target;
	 public GameObject bullet;

	 public float timer;
	 public bool canshoot;
	 public int damage;
	 
 public float MoveSpeed = 4;
 public float  MaxDist = 10;
 public float MinDist = 5;
 public bool isInMine;
 public int force;

 public Transform entradader;
 public Transform entradaizq;

	// Use this for initialization
	void Start () {
		//target=GameObject.FindGameObjectWithTag("Player");
		CalcDis();


	}
	  void FixedUpdate () {

     if(Vector2.Distance(transform.position,target.transform.position) >= MinDist){
    Vector3 vectorToTarget = target.transform.position - transform.position;
    transform.position += vectorToTarget.normalized * MoveSpeed * Time.deltaTime;
         //transform.Translate(toTarget * MoveSpeed * Time.deltaTime);
		 
	 }
     }
	
	// Update is called once per frame
	void Update () {
			if(GameObject.FindGameObjectWithTag("Player")==null){
			return;
			}
		
		if(isInMine==false &&GameObject.FindGameObjectWithTag("Player").GetComponent<Platformer_Move>().isInMine==false ){
			target=GameObject.FindGameObjectWithTag("Player");
		}
		if(isInMine==false &&GameObject.FindGameObjectWithTag("Player").GetComponent<Platformer_Move>().isInMine==true ){
			CalcDis();
		}
				if(isInMine==true &&GameObject.FindGameObjectWithTag("Player").GetComponent<Platformer_Move>().isInMine==true ){
			target=GameObject.FindGameObjectWithTag("Player");
		}



		AttackTimer();
		
		
     
     if(Vector2.Distance(transform.position,target.transform.position) >= MinDist){
		 				  		
			//GameObject.Find("Player").GetComponent<PlayerHealth>().HP-=damage;
			// Vector2 dir = other.contacts[0].point - new Vector2(transform.position.x,transform.position.y);
			// dir = -dir.normalized;
			//GetComponent<Rigidbody2D>().AddForce(dir*force);

     
        //transform.position = Vector2.MoveTowards ( new Vector2(transform.position.x,transform.position.y),new Vector2(Player.transform.position.x,transform.position.y), MoveSpeed * Time.deltaTime );
		//transform.position = Vector2.MoveTowards ( new Vector2(transform.position.x,transform.position.y),Player.transform.position, MoveSpeed * Time.deltaTime );
	 }
           
          if(Vector2.Distance(transform.position,target.transform.position) <= MinDist+1)
              {

		}

    }
			  

		
	

 private void AttackTimer()
 {
     timer -= Time.deltaTime;
     if (timer < 0)
     {
canshoot=true;

     }

}
private void OnTriggerEnter2D(Collider2D other) {
	if(other.gameObject.name=="Arriba"){
		isInMine=false;
	}
		if(other.gameObject.name=="Mina"){
		isInMine=true;
	}
	
	
}
void CalcDis(){
		entradaizq=GameObject.Find("EntradaIzq").transform;
		entradader=GameObject.Find("EntradaDer").transform;
		float dist;
		float dist2;
		dist=Vector2.Distance(transform.position,entradader.position);
		dist2=Vector2.Distance(transform.position,entradaizq.position);
		if(dist>=dist2){
		target=GameObject.Find("EntradaIzq");
			
		}
		else if (dist<=dist2){
		target=GameObject.Find("EntradaDer");
		}

}
private void OnTriggerStay2D(Collider2D other) {
	if(other.gameObject.name=="Arriba"){
		isInMine=false;
	}
		if(other.gameObject.name=="Mina"){
		isInMine=true;
	}

}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag=="Player"&&canshoot==true){
			other.gameObject.GetComponent<PlayerHealth>().HP-=damage;
			 Vector2 dir = other.contacts[0].point - new Vector2(transform.position.x,transform.position.y);
			 dir = -dir.normalized;
			other.gameObject.GetComponent<Rigidbody2D>().AddForce(dir*force);
			canshoot=false;
			timer=1;
		
		}
	}
}
