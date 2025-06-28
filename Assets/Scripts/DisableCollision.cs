using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableCollision : MonoBehaviour {
public bool Col = true;
public GameObject Killzone;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Col==false){
			GetComponent<Collider2D>().enabled=false;
			Killzone.SetActive(false);
		}



		
	}
	void OnCollisionEnter2D(Collision2D col)
  {
    if (col.gameObject.tag == "Fire")

      {
		
		{
			Col=false;
		}
      }
  } 
}
