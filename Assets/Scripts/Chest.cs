using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {
	public GameObject[] loot;
	public int[] itemstospawn;
	
	public GameObject OpenedChest;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag=="Player"){
			Instantiate(OpenedChest,transform.position,transform.rotation);
			int dice=Random.Range(itemstospawn[0],itemstospawn[1]);
 for (int i = 0; i < dice; i++) {
 GameObject lootfromchest= Instantiate(loot[Random.Range(0,loot.Length)],transform.position,transform.rotation);
 lootfromchest.AddComponent<randomforce>();
 }

			
			Destroy(gameObject);
			
		}
		
	}
}
