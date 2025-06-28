using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour {
	public int offset;
	public static float armrot;
	private float x; 
	private Vector3 ls;

 void Start() {
         x = transform.localScale.x;
         ls = transform.localScale;
     }
     
     void Update () {
         Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position);  
 
         float rotZ = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
 
         if (dir.x >= 0) {
             transform.rotation = Quaternion.Euler  (0f, 0f, rotZ);
 
             ls.x = x;
             transform.localScale = ls;
         }
         else {
             transform.rotation = Quaternion.Euler  (0f, 0f, rotZ+180);
             ls.x = -x;
             transform.localScale = ls;
         }
     }
 }

