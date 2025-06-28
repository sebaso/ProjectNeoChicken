using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {
    public int offsetX = 2;
    public bool hasAbuddyright=false;
    public bool hasABuddyleft = false;
    public bool reversescale = false;
    private float spriteWidth = 0f;
    private Camera cam;
    private Transform myTransform;
    private void Awake()
    {
        cam = Camera.main;
        myTransform = transform;

    }
    // Use this for initialization
    void Start () {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x;
		
	}
	
	// Update is called once per frame
	void Update () {
        if(hasABuddyleft == false || hasAbuddyright == false)
        {
            float camhorizontalextend = cam.orthographicSize * Screen.width / Screen.height;
            float EdgeVisiblePosRight = (myTransform.position.x + spriteWidth / 2) - camhorizontalextend;
            float EdgevisibleposLeft = (myTransform.position.x - spriteWidth / 2) + camhorizontalextend;
            if(cam.transform.position.x >=EdgeVisiblePosRight-offsetX && hasAbuddyright == false)
            {
                makeBuddy(1);
                hasAbuddyright = true;
            }
            else if(cam.transform.position.x <= EdgevisibleposLeft +offsetX && hasABuddyleft == false)
            {
                makeBuddy(-1);
                hasABuddyleft = true;
            }
        }
		
	}
    void makeBuddy(int rightOrLeft)  
 
    {

        Vector3 newpos = new Vector3 (myTransform.position.x + spriteWidth * rightOrLeft,myTransform.position.y,myTransform.position.z);
        Transform newBuddy = Instantiate(myTransform, newpos, myTransform.rotation) as Transform;
        if (reversescale == true)
        {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1,newBuddy.localScale.y,newBuddy.localScale.z);
        }
        newBuddy.parent = myTransform;
        if (rightOrLeft > 0)
        {
            newBuddy.GetComponent<Tiling>().hasABuddyleft = true;

        }
        else
        {
            newBuddy.GetComponent<Tiling>().hasAbuddyright = true;
        }
    }

}
