using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_Manager : MonoBehaviour {
	public Transform[] chest_pos;
	public int prev_round;
	public int curr_round;
	public GameObject chest;

	// Use this for initialization
	void Start () {
		curr_round=0;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Round_GM.Round!=curr_round){
			ChestSpawn();
			curr_round=Round_GM.Round;

			
		}
		
	}
	void ChestSpawn(){
		Vector3 pos=chest_pos[Random.Range(0,chest_pos.Length)].position;
	
		Instantiate(chest,pos,transform.rotation);

	}

}
