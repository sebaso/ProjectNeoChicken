using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour {
	private PlayerHealth player;
	public Slider hp;

	// Use this for initialization
	void Start () {
		player=GameObject.Find("Player").GetComponent<PlayerHealth>();
		
	}
	
	// Update is called once per frame
	void Update () {
		hp.value=player.HP/player.MaxHP;
		
		
	}
}
