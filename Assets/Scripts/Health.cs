using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public float DamageTaken;
	public float HP;
	public GameObject Gib;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (HP<=0){
			Instantiate(Gib,transform.position,transform.rotation);
			GameObject.Find("_GM").GetComponent<Round_GM>().EnemiesKilled++;
			GameObject.Find("_GM").GetComponent<Round_GM>().EnemiesKilledTotal++;
			Destroy(gameObject);
		}
		
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag=="Fire"){
			DamageTaken= other.gameObject.GetComponent<BulletCtrl>().Damage;

			HP-=DamageTaken;
		}
	}
}
