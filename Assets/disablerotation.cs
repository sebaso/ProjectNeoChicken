using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disablerotation : MonoBehaviour {
	public GameObject reference;
	public string nombre;

	// Use this for initialization
	void Start () {
		reference=GameObject.Find(nombre);
		
	}
	
	// Update is called once per frame
	void Update () {
		if(reference.activeInHierarchy==false){
			Destroy(gameObject);

		}
		transform.rotation=  new Quaternion(0,0,0,0);

		
	}
}
