using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
	public int delay;
	public  bool hasExploded=false;
	public bool hasdmged=false;
	public GameObject explotionEffect;
	public float radius=5f;
	public float force=3f;
	public bool bounced=false;

	float countdown;
	// Use this for initialization
	void Start () {
		countdown=delay;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		countdown -= Time.deltaTime;
		if (countdown<= 0f&& hasExploded==false){
		Triggerexplosion();
		}

	}
		void LateUpdate()
		{

		
		}
		
	void ExplodeDMG(){
						Collider2D[] gotodmg = Physics2D.OverlapCircleAll(transform.position,radius);
		foreach (Collider2D nearbyobject in gotodmg){
			Health he= nearbyobject.GetComponent<Health>();
			if(he!=null){
				he.HP-=50;
				hasdmged=true;
				
			}
		}
		
	}
	void ExplodeForce(){
		Instantiate(explotionEffect,transform.position,new Quaternion(0,0,0,0));
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,radius);
		foreach (Collider2D nearbyobject in colliders){
			Rigidbody2D rb=nearbyobject.GetComponent<Rigidbody2D>();
			GameObject go=nearbyobject.GetComponent<GameObject>();
			if(rb!= null){
				rb.AddExplosionForce2(force,transform.position,radius);
				//rb.AddForce(new Vector2(5,5),ForceMode2D.Impulse);
				//rb.AddForceAtPosition(new Vector2(5,5),transform.position,ForceMode2D.Impulse);
hasExploded=true;
					}
				
				
		}
		


	}
	void Triggerexplosion(){
					ExplodeDMG();
			hasExploded=true;
			GetComponent<SpriteRenderer>().enabled=false;
			GetComponent<Rigidbody2D>().simulated=false;
			GetComponent<Collider2D>().enabled=false;
			Invoke("ExplodeForce",0.1f);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag!="Enemy")
		bounced=true;
		if(other.gameObject.tag=="Enemy"&&bounced==false)
		{
			Triggerexplosion();

		}
	}
}

	
