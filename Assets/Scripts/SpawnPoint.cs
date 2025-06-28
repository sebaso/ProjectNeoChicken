using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	// Use this for initialization
public Transform player;
public int distance= 50;
public bool canspawn;
public float timer;
private bool playerCloseEnough = false;
public GameObject enemy;
private bool spawned;
public float TimeLimit=5f;


void Start()
{
	 player=GameObject.Find("Player").transform;
}




void Update(){
	Timer();
    if(Vector2.Distance(transform.position, player.position) > distance){
       
        playerCloseEnough=true;
    }
    else{
        playerCloseEnough=false;
    }
	if(playerCloseEnough==true&&canspawn==true){
        if(GameObject.Find("_GM").GetComponent<Round_GM>().StopSpawns!=true){

        if(GameObject.Find("_GM").GetComponent<Round_GM>().spawnlimit!=true){
		Instantiate(enemy,this.transform.position,this.transform.rotation);
		canspawn=false;
		timer=(TimeLimit-Round_GM.Round*0.4f);
		spawned=true;
        GameObject.Find("_GM").GetComponent<Round_GM>().enemiesSpawned++;
        }
	}
    }

}
 private void Timer()
 {
     timer -= Time.deltaTime;
     if (timer < 0)
     {
canspawn=true;

     }

}
}
