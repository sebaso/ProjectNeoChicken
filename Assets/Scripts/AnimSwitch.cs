
using UnityEngine;

public class AnimSwitch : MonoBehaviour {

	public int selectedSprite=0;



	// Use this for initialization
	void Start () {
		selectSprite();

		
	}
	
	// Update is called once per frame
	void Update () {
		int previousselectedSprite=selectedSprite;


if(WeaponSwitch.globalweapon==0)
{
	selectedSprite=0;
}
if(WeaponSwitch.globalweapon==1){
	selectedSprite=1;
}
if(WeaponSwitch.globalweapon==2){
	selectedSprite=2;
}
if(previousselectedSprite!=selectedSprite){
	selectSprite();
}
}
	void selectSprite()
	{
		int i =0;
	foreach (Transform weapon in transform)
	{
		if(i==selectedSprite)
			weapon.gameObject.SetActive(true);
		else
			weapon.gameObject.SetActive(false);
		i++;
	}

}
}


	

