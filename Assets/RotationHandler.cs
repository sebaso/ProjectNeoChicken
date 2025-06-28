using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHandler : MonoBehaviour {
	public Transform playerposx;
	public Transform posx;
	public bool flipX=false;


	// Use this for initialization
	void Start () {
		if(GetComponent<Butcher_AI>()!=null){
		playerposx=GetComponent<Butcher_AI>().target.transform;
		}
		else{
		playerposx=GetComponent<BasicAI>().target.transform;
		}

		posx=GetComponent<Transform>();
		
	}
	
	// Update is called once per frame

		   void Update () {
			   		if(GetComponent<Butcher_AI>()!=null){
		playerposx=GetComponent<Butcher_AI>().target.transform;
		}
		else if(playerposx!=null){
		playerposx=GetComponent<BasicAI>().target.transform;
		}
		else
		return;


			   if(playerposx.position.x<posx.position.x){
				   flipX=true;
			   }
			   else 
			   flipX=false;
			   if(flipX==true){
				   			   SpriteRenderer[] allChildren = GetComponentsInChildren<SpriteRenderer>();
								foreach (SpriteRenderer child in allChildren)
									{
    								child.flipX=true;
									}
			   }
			
				 if(flipX==false){
				   			   SpriteRenderer[] allChildren = GetComponentsInChildren<SpriteRenderer>();
								foreach (SpriteRenderer child in allChildren)
									{
    								child.flipX=false;
									}
			   }

         }
		 
     }
		
	

