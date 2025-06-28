using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapWeapons : MonoBehaviour {
	public Sprite[] weapon;
	public Sprite[] ammo;
	public Image currentweaponImage;
	public int currentweapon;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q)){
			NextWeapon();

		}
		
	}
	void ChangeWeapon(){
		currentweaponImage.sprite=weapon[currentweapon];

	}
	void NextWeapon(){
		currentweapon++;
		if(currentweapon>=weapon.Length){
			currentweapon=0;
		}
		ChangeWeapon();
	}
}
