using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeHolder : MonoBehaviour {

 private Vector3 mousePosition;
	public Vector3 pivot;
	public Vector3 pivotoff;
    public Platformer_Move playerRef;
	public bool looking_right;
	private float x; 
	private Vector3 ls;

        void Start(){
			playerRef=GameObject.Find("Player").GetComponent<Platformer_Move>();
			         x = transform.localScale.x;
         ls = transform.localScale;
           
			 
        }

    void Update(){
		if(PauseMenu.GamePaused)
		return;
		looking_right=playerRef.lookingRight;
	    mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

	    Vector3 difference = mousePosition - transform.position;
	    difference.Normalize ();
	    float rotZ=Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;

	    if (looking_right==true) {
			
		    transform.localPosition=(pivot); 
	    } 
		else {
			
			transform.localPosition=(pivotoff);
		   
	    }
		Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position);  
 
         float rotZ1 = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		         if (dir.x >= 0) {
 
 
             ls.x = x;
             transform.localScale = ls;
         }
         else {
        
             ls.x = -x;
             transform.localScale = ls;
         }
	}
}
