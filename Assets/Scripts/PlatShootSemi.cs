using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatShootSemi : MonoBehaviour {

	public float FireRate = 15f;
	public float Damage = 10f;
	public GameObject bullet;
	public float speed=7f;
	float TimeToFire=0f;
	public int clip;
	public int bulletsleft;
	public bool isreloading=false;
	public float ReloadTime;
	Transform firepoint;
	private float nextimetofire=0f;
	public Text ammocounter;
	public bool dropcases;
	public GameObject bulletcase;
	public bool isGrenade;
	public Animator grenade;

	// Use this for initialization
	void Awake () {
		firepoint=transform.Find("ShootPoint");	
		if (firepoint==null)
		{
			Debug.LogError("No Firepoint u noob");
		}

		
		
	}
	private void Start() {
		bulletsleft=clip;


	}
	private void OnEnable() {
		isreloading=false;
		//ammocounter.text=clip.ToString();
		
	}
	
	// Update is called once per frame
	void Update (){
		if(isGrenade==false){
		if(PauseMenu.GamePaused)
		return;
			ammocounter.text=(bulletsleft.ToString()+"/"+clip.ToString());
		
		if(isreloading)
		return; 
		if(bulletsleft==0){
			StartCoroutine(Reload());
			return;
		}
		if(Input.GetKeyDown(KeyCode.R)){
			if(bulletsleft!=clip){
				StartCoroutine(Reload());
				return;
			}
		}
	
			if(Input.GetKey(KeyCode.Mouse0) && Time.time >= nextimetofire){
				
				nextimetofire=Time.time+1f/FireRate;
				Shoot2();
			
				}
			

			


		

			}
			else{

				bulletsleft=Platformer_Move.Grenades;
				ammocounter.text=(bulletsleft.ToString());
				if(Input.GetKey(KeyCode.Mouse0) && Time.time >= nextimetofire){
					if(bulletsleft==0){
						return;
					}
				
				nextimetofire=Time.time+1f/FireRate;
				Shoot2();
				Platformer_Move.Grenades--;
				StartCoroutine("AnimThrown");


			
				}

			}

	}
			IEnumerator AnimThrown(){
				grenade.SetBool("Thrown",true);

				yield return new WaitForSeconds(0.5f);
				grenade.SetBool("Thrown",false);
			}
			
			IEnumerator Reload(){
				isreloading=true;
				yield return new WaitForSeconds(ReloadTime);
				bulletsleft=clip;
				isreloading=false;


				

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
             Quaternion rotation = Quaternion.Euler( 0, 0,Mathf.Atan2 ( direction.y, direction.x ) * Mathf.Rad2Deg );
			bulletsleft--;
            GameObject projectile = Instantiate( bullet, myPos, rotation);
            projectile.GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
			if(projectile.GetComponent<BulletCtrl>()!=null){
			projectile.GetComponent<BulletCtrl>().Damage=Damage;
			if(dropcases==true){
				Transform casepoint=GameObject.Find("CasePoint").transform;
				Instantiate(bulletcase,casepoint.position,casepoint.rotation);
			}
			}
		
         
}
void GrenadeShoot(){
	
             Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x,  Input.mousePosition.y) );
             Vector2 myPos = new Vector2(firepoint.position.x,firepoint.position.y );
             Vector2 direction = target - myPos;
             direction.Normalize();
             Quaternion rotation = Quaternion.Euler( 0, 0,Mathf.Atan2 ( direction.y, direction.x ) * Mathf.Rad2Deg );
			bulletsleft--;
            GameObject projectile = Instantiate( bullet, myPos, rotation);
            projectile.GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
			if(projectile.GetComponent<BulletCtrl>()!=null){
			projectile.GetComponent<BulletCtrl>().Damage=Damage;
			if(dropcases==true){
				Transform casepoint=GameObject.Find("CasePoint").transform;
				Instantiate(bulletcase,casepoint.position,casepoint.rotation);
			}
			}
		
         
}

}	
