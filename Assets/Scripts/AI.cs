using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class AI : MonoBehaviour {
public Transform target;
public float UpdateRate =2f;
private Seeker seeker;
public int speed= 10;
private Rigidbody2D rb;
 public Path path;

 public ForceMode2D fmode;
 [HideInInspector]
 public bool PathIsEnded = false;
 public float NextWPDis =3f;
 private int currentWaypoint;

 void Start()
 {
	 seeker=GetComponent<Seeker>();
	 rb=GetComponent<Rigidbody2D>();
	 target=GameObject.Find("Player").transform;
	 if (target==null){
		 Debug.LogError("No target");
		return ;
	 }
 
	 seeker.StartPath(transform.position,target.position,OnPathComplete);
	 StartCoroutine(UpdatePath());
 }

	 IEnumerator UpdatePath() {
		 if (target==null){
		yield return null;
		 }
		 seeker.StartPath(transform.position,target.position, OnPathComplete);
		 yield return new WaitForSeconds(1f/UpdateRate);
		 StartCoroutine(UpdatePath());
	 }
 
public void OnPathComplete(Path p){

	if(!p.error){
		path=p;
		currentWaypoint=0;
		
	}
}	

	void FixedUpdate()
	{
	 	if (target==null)
		   return;
		 
		 if(path==null)
				return;
		 
		 if(currentWaypoint>=path.vectorPath.Count){
			 if(PathIsEnded)
				return;
			 PathIsEnded=true;
			 return;
		 }
		 PathIsEnded=false;
		 Vector3 dir =(path.vectorPath[currentWaypoint] -transform.position).normalized;
		 dir*=speed*Time.fixedDeltaTime;

		 rb.AddForce(dir,fmode);

		 float dist=Vector3.Distance (transform.position, path.vectorPath[currentWaypoint]);

		 if(dist<NextWPDis){
			 currentWaypoint++;
			 return;
		 }
	

	}

}


