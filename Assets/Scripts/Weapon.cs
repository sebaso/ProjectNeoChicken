using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public float FireRate = 0f;
	public float Damage = 10f;
	public LayerMask NotToHit;
	public GameObject bullet;


	public float speed=7f;
	float TimeToFire=0f;
	Transform firepoint;

	// Use this for initialization
	void Awake () {
		firepoint=transform.Find("ShootPoint");	
		if (firepoint==null)
		{
			Debug.LogError("No Firepoint u noob");
		}

		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(FireRate==0){
			if(Input.GetButtonDown("Fire1")){
				Shoot();
			}
		}
		else{
			if(Input.GetButton("Fire1") && Time.time < TimeToFire){
				TimeToFire = Time.time + 1/FireRate;
				Shoot();
			}
		}
	}
	void Shoot(){

             Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x,  Input.mousePosition.y) );
             Vector2 myPos = new Vector2(transform.position.x,transform.position.y);
             Vector2 direction = target - myPos;
             direction.Normalize();
    
             GameObject projectile = (GameObject) Instantiate( bullet, firepoint.position,bullet.transform.rotation);

}
void Shoot2(){
	
             Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x,  Input.mousePosition.y) );
             Vector2 myPos = new Vector2(firepoint.position.x,firepoint.position.y + 1);
             Vector2 direction = target - myPos;
             direction.Normalize();
             Quaternion rotation = Quaternion.Euler( 0, 0, -90+Mathf.Atan2 ( direction.y, direction.x ) * Mathf.Rad2Deg );
		
             GameObject projectile = (GameObject) Instantiate( bullet, myPos, rotation);
             projectile.GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
         
}
}	
