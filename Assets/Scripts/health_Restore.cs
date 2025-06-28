using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_Restore : MonoBehaviour {
	public float restoreammount;
	public bool pickup;

	// Use this for initialization
	void Start () {
		StartCoroutine("togglepickup");
		
	}
		IEnumerator togglepickup(){
		yield return new WaitForSeconds(0.5f);
		pickup=true;

	}
	
	// Update is called once per frame
	void Update () {

		

		
	}






void OnTriggerEnter2D(Collider2D other){
		
		if(other.gameObject.tag=="Player"){
		if(pickup==false)
		return;
			if(other.gameObject.GetComponent<PlayerHealth>()){
								if(other.gameObject.GetComponent<PlayerHealth>().HP==other.gameObject.GetComponent<PlayerHealth>().MaxHP){
				return;}
				other.gameObject.GetComponent<PlayerHealth>().HP+=restoreammount;
				if(other.gameObject.GetComponent<PlayerHealth>().HP>=other.gameObject.GetComponent<PlayerHealth>().MaxHP){
				other.gameObject.GetComponent<PlayerHealth>().HP=other.gameObject.GetComponent<PlayerHealth>().MaxHP;
				}
				Destroy(gameObject);
			}

		}
	}
}


