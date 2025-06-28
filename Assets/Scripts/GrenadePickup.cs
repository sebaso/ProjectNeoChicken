using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePickup : MonoBehaviour {
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
		if(pickup==false)
		return;
		

		
	}
	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnCollisionEnter2D(Collision2D other)
	{
		if(pickup==false)
		return;
		if(other.gameObject.tag=="Player"){
			Platformer_Move.Grenades++;
			Destroy(gameObject);
			Debug.Log(Platformer_Move.Grenades);
		}
	}
}
