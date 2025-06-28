
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {

	public int selectedWeapon=0;
	public static int globalweapon;


	// Use this for initialization
	void Start () {
		selectWeapon();

		
	}
	
	// Update is called once per frame
	void Update () {
		globalweapon=selectedWeapon;
		int previousselectedweapon=selectedWeapon;
		if(Input.GetAxis("Mouse ScrollWheel")<0f)
		{
			if(selectedWeapon>=transform.childCount-1)
				selectedWeapon=0;
			else
				selectedWeapon++;
		}
		if(Input.GetAxis("Mouse ScrollWheel")>0f)
		{
			if(selectedWeapon<=0)
				selectedWeapon=transform.childCount-1;
			else
				selectedWeapon--;
	}

if(Input.GetKey(KeyCode.Alpha1))
{
	selectedWeapon=0;
}
if(Input.GetKey(KeyCode.Alpha2)){
	selectedWeapon=1;
}
if(Input.GetKey(KeyCode.Alpha3)){
	selectedWeapon=2;
}
if(previousselectedweapon!=selectedWeapon){
	selectWeapon();
}
	}
	void selectWeapon()
	{
		int i =0;
	foreach (Transform weapon in transform)
	{
		if(i==selectedWeapon)
			weapon.gameObject.SetActive(true);
		else
			weapon.gameObject.SetActive(false);
		i++;
	}

}
}


	

