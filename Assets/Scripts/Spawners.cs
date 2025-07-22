using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour {
	public bool IsGoreSpawner;

	// Use this for initialization
	void Start () {
		if(IsGoreSpawner==true&&PlayerPrefs.GetInt("Gore")==1){
			Destroy(GameObject.Find("Spawners"));
		}
		if(IsGoreSpawner==false&&PlayerPrefs.GetInt("Gore")==1){
			Destroy(GameObject.Find("Spawners"));
		}
			if(IsGoreSpawner==true&&PlayerPrefs.GetInt("Gore")==0){
			Destroy(GameObject.Find("Spawners (Extra Gore)"));
		}
		if(IsGoreSpawner==false&&PlayerPrefs.GetInt("Gore")==0){
			Destroy(GameObject.Find("Spawners (Extra Gore)"));
		
	}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
