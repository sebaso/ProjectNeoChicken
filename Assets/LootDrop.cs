using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour {
	public GameObject[] loot;
	public int chance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnDestroy()
	{
		int food=Random.Range(0,loot.Length);
		int dice=Random.Range(chance,101);
		if(dice==100){
			Instantiate(loot[food],transform.position,transform.rotation);
		}

		
	}
}
