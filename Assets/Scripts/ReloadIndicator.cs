using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadIndicator : MonoBehaviour {
	public PlatShootSemi gun;
	public GameObject reloj;
	public bool spawned=false;

	// Use this for initialization
	void Start () {
		gun.GetComponent<PlatShootSemi>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gun.isreloading){
			if(spawned==false){
				spawn();
			spawned=true;
		}	
	}
			if(gun.isreloading==false){
			spawned=false;
		}
	}
	void spawn(){
				GameObject indicador=Instantiate(reloj,new Vector2(transform.position.x,transform.position.y+0.8f),new Quaternion(0,0,0,0));
				indicador.gameObject.transform.parent=GameObject.Find("Player").transform;
	}

}

