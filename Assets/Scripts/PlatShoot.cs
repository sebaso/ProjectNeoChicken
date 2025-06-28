using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlatShoot : MonoBehaviour {


	public float FireRate = 15f;
	public float Damage = 10f;
	public GameObject bullet;
	public float speed=7f;
	float TimeToFire=0f;
	
	Transform firepoint;
	private float nextimetofire=0f;

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
	
			if(Input.GetKey(KeyCode.Mouse0) && Time.time >= nextimetofire){
				nextimetofire=Time.time+1f/FireRate;
				Shoot2();
			}

		

			}

	

		

	
	void Shoot(){

             Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x,  Input.mousePosition.y) );
             Vector2 myPos = new Vector2(transform.position.x,transform.position.y);
             Vector2 direction = target - myPos;
             direction.Normalize();
             Quaternion rotation = Quaternion.Euler( 0, 0, -90);
             GameObject projectile = (GameObject) Instantiate( bullet, myPos, rotation);
             projectile.GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
}
void Shoot2(){
	
             Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x,  Input.mousePosition.y) );
             Vector2 myPos = new Vector2(firepoint.position.x,firepoint.position.y );
             Vector2 direction = target - myPos;
             direction.Normalize();
             Quaternion rotation = Quaternion.Euler( 0, 0, -90+Mathf.Atan2 ( direction.y, direction.x ) * Mathf.Rad2Deg );
		
            GameObject projectile = Instantiate( bullet, myPos, rotation);
            projectile.GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
         
}

}	
