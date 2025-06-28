using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundCompleted : MonoBehaviour {
	public int prev_round;
	public int curr_round;
	public float timefortext;
	public GameObject text;

	// Use this for initialization
	void Start () {
		curr_round=1;
		
	}
	
	// Update is called once per frame
	void Update () {
				if(Round_GM.Round!=curr_round){
					curr_round=Round_GM.Round;
					StartCoroutine(Toggletext());
			
		

			
		}
		
	}
	IEnumerator Toggletext(){
		text.SetActive(true);
		 yield return new WaitForSeconds(timefortext);
		 text.SetActive(false);

		
	}
}
