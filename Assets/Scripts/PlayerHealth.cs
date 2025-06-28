using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public float DamageTaken;
	public float HP;
	public GameObject Gib;
	public bool ded;
	public float MaxHP;
	public Text healthText;

	// Use this for initialization
	void Start () {
		HP=MaxHP;
		
	}
	
	// Update is called once per frame
	void Update () {
				if (HP<=0&&ded==false){
			Instantiate(Gib,transform.position,transform.rotation);
			GetComponent<Platformer_Move>().enabled=false;
			GetComponent<Rigidbody2D>().simulated=false;
			GameObject.Find("_GM").GetComponent<Round_GM>().EnemiesKilled++;
			GameObject.Find("_GM").GetComponent<Round_GM>().EnemiesKilledTotal++;
			GameObject[] weapons =GameObject.FindGameObjectsWithTag("Weapon");
			GameObject[] sprites =GameObject.FindGameObjectsWithTag("Sprites");
			GameObject.Find("Weapon Holder").GetComponent<WeaponSwitch>().enabled=false;
			GetComponent<SpriteRenderer>().enabled=false;
			foreach(GameObject weapon in weapons){
				weapon.GetComponent<PlatShootSemi>().enabled=false;
				weapon.GetComponent<SpriteRenderer>().enabled=false;

			}
			foreach(GameObject sprite in sprites){
				sprite.GetComponent<SpriteRenderer>().enabled=false;
			}
			ded=true;
			if(HP<=0)
			HP=0;
			
		}
		healthText.text=HP.ToString();
		
	}
		void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag=="EnemyBullet"){
			DamageTaken= other.gameObject.GetComponent<BulletCtrl>().Damage;

			HP-=DamageTaken;
		}
	}

}
