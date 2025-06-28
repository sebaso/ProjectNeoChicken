using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour {
	 public GameObject target;
	 public GameObject bullet;
	 public int speed;
	 public float timer;
	 public bool canshoot;
	 public bool lookingRight=true;
 public int MoveSpeed = 4;
 public int MaxDist = 10;
 public int MinDist = 5;
  public bool isInMine;

 public Transform entradader;
 public Transform entradaizq;

	// Use this for initialization
	void Start () {
		CalcDis();
		target=GameObject.FindGameObjectWithTag("Player");
		
	}
	 void FixedUpdate() {
		
	}
	// Update is called once per frame
	void Update () {
						  			if(GameObject.FindGameObjectWithTag("Player")==null){
			return;
			}

		
				if(isInMine==false &&GameObject.FindGameObjectWithTag("Player").GetComponent<Platformer_Move>().isInMine==false ){
					MinDist=5;
			target=GameObject.FindGameObjectWithTag("Player");
		}
		if(isInMine==false &&GameObject.FindGameObjectWithTag("Player").GetComponent<Platformer_Move>().isInMine==true ){
			MinDist=0;
			CalcDis();
		}
				if(isInMine==true &&GameObject.FindGameObjectWithTag("Player").GetComponent<Platformer_Move>().isInMine==true ){
			target=GameObject.FindGameObjectWithTag("Player");
			MinDist=5	;
		}

		AttackTimer();

		
     
     if(Vector2.Distance(transform.position,target.transform.position) >= MinDist){


          transform.position = Vector2.MoveTowards ( new Vector2(transform.position.x,transform.position.y),target.transform.position, MoveSpeed * Time.deltaTime );
 
	 }
           
          if(Vector2.Distance(transform.position,target.transform.position) <= MinDist+1)
              {

Shoot();
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
private void Shoot(){
	if(canshoot==true){
		canshoot=false; 
        GameObject firedbullet =Instantiate(bullet,	new Vector2(transform.position.x,transform.position.y),Quaternion.Euler(0,0,0));
		firedbullet.transform.position= Vector2.MoveTowards(firedbullet.transform.position,GameObject.Find("Player").gameObject.transform.position,speed*Time.deltaTime);
		firedbullet.GetComponent<Rigidbody2D>().linearVelocity = (GameObject.Find("Player").transform.position - transform.position).normalized * speed;
		canshoot=false;
		timer=5;
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
private void OnTriggerEnter2D(Collider2D other) {
	if(other.gameObject.name=="Arriba"){
		isInMine=false;
	}
		if(other.gameObject.name=="Mina"){
		isInMine=true;
	}
	
}
}

