using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour {


     public Transform farLeft;  // End of screen Left
     public Transform farRight;  //End of Screen Right
     public Transform bottom;
     void Update() {

 
             if(transform.position.x > farRight.position.x-5)
                 transform.position = new Vector3(farRight.position.x-5, transform.position.y,transform.position.z);
 
             if(transform.position.x < farLeft.position.x+5)
                 transform.position = new Vector3(farLeft.position.x+5, transform.position.y,transform.position.z);
            if(transform.position.y < bottom.position.y+5){
                transform.position = new Vector3(transform.position.x, bottom.position.y+5,transform.position.z);
            }
         }
     }
 

