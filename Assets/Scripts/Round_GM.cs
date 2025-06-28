using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round_GM : MonoBehaviour {
	public int EnemiesKilled;
	public int EnemiesKilledTotal;

	public int TimeBetween=15;
	public bool StopSpawns;
	public Text EnemiesKilledText;
	public Text RoundText;
	public int enemiesSpawned;
	public static int  Round;
	
	public  int EnemyCount;
	
	public  int EnemyCap=50;
	
	public  bool spawnlimit;


	// Use this for initialization
	void Start () {
		Round=1;
		
	}
	
	// Update is called once per frame
	void Update () {
		EnemyCount= GameObject.FindGameObjectsWithTag("Enemy").Length;


if(enemiesSpawned>=EnemyCap){
	spawnlimit=true;}
	else{
		spawnlimit=false;

	}
		if(EnemiesKilled>=EnemyCap){
			Debug.Log("Round passed.");
			EnemiesKilled+=EnemiesKilledTotal;
			EnemiesKilled=0;
			StartCoroutine(EnableTimedBonus());
			Round++;
			enemiesSpawned=0;
			EnemyCap=EnemyCap+(Round*10);
		}
		RoundText.text=("Round: "+Round.ToString());
		EnemiesKilledText.text=("Enemies Killed:  "+EnemiesKilled.ToString()+"/"+enemiesSpawned.ToString());

	}
	 IEnumerator EnableTimedBonus()
 	{
        StopSpawns=true;
         yield return new WaitForSeconds(TimeBetween);
		 StopSpawns=false;
		   GameObject[] gibs = GameObject.FindGameObjectsWithTag("Gib");
   foreach(GameObject gib in gibs)
   GameObject.Destroy(gib);
         
 	}
		
}

