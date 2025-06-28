using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Platformer_Move : MonoBehaviour {
    public Animator anim;
    public static int Grenades=0;


    public float movespeed;
	public float JumpSpeed;
    public Rigidbody2D rb;
    public bool Grounded;
    public LayerMask Ground;
    public Collider2D PlayerCollider;
    public bool isJumping = false;
    public bool isJumping2 = false;
    public bool moving=false;
    public bool lookingRight=true;
    public bool running;
    public bool jumping;
    private GameObject sp;
    public bool isInMine;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim= GameObject.Find("Player").GetComponent<Animator>();
        sp= GameObject.Find("Player");

        
    }
    private void OnTriggerStay2D(Collider2D other) {
	if(other.gameObject.name=="Arriba"){
		isInMine=false;
	}
		if(other.gameObject.name=="Mina"){
		isInMine=true;
	}
}

    void FixedUpdate()
    {
        //Move();
    }
    void Update()
    {
        if(rb.linearVelocity.normalized.x!=0){
            running=true;
        }
            else
            
            running=false;
        if(running==true){
            anim.SetBool("IsRunning",true);
        }
        if(running==false){
            anim.SetBool("IsRunning",false);
        }
        
        if(jumping==true){
            anim.SetBool("IsJumping",true);
        }
        if(jumping==false){
            anim.SetBool("IsJumping",false);
        }

        



        Anim();
        Move();
        if(lookingRight==false){
            sp.GetComponent<SpriteRenderer>().flipX=true;
        }
                if(lookingRight==true){
            sp.GetComponent<SpriteRenderer>().flipX=false;


        }
        if(WeaponSwitch.globalweapon==0){
        anim= GameObject.Find("Player").GetComponent<Animator>();
        sp= GameObject.Find("Player");

        

        }
        if(WeaponSwitch.globalweapon==1){
        anim= GameObject.Find("Player").GetComponent<Animator>();
        sp= GameObject.Find("Player");
        
        }
        if(WeaponSwitch.globalweapon==2){
        anim= GameObject.Find("Player").GetComponent<Animator>();
        sp= GameObject.Find("Player");
        }
      
 

    }

  



void Move()
{
    	if(Input.GetKeyUp(KeyCode.A)){
            if(isJumping==true){
                rb.linearVelocity= new Vector2(rb.linearVelocity.x, rb.linearVelocity.y);
            }
else
rb.linearVelocity= new Vector2(rb.linearVelocity.x*0.2f, rb.linearVelocity.y);
        }
        if(Input.GetKeyUp(KeyCode.D)){
            if(isJumping==true){
                rb.linearVelocity= new Vector2(rb.linearVelocity.x, rb.linearVelocity.y);
            }
else
rb.linearVelocity= new Vector2(rb.linearVelocity.x*0.2f, rb.linearVelocity.y);
        }

	    if(Input.GetKey(KeyCode.A)){
         rb.linearVelocity= new Vector2(-movespeed, rb.linearVelocity.y);
           lookingRight=false;
        }

		
		if(Input.GetKey(KeyCode.D)){
            rb.linearVelocity= new Vector2(movespeed, rb.linearVelocity.y);
         lookingRight=true;
        }

      if (Input.GetKeyDown (KeyCode.Space)||Input.GetKeyDown(KeyCode.W)) 
      {
          if (isJumping == false && isJumping2==false) 
          {
              Jump();
              isJumping = true;
          }
          else if (!isJumping2)
          {
             Jump();
            isJumping2 = true;
          }
  
      }


}
void Anim(){
    if(Input.GetKeyUp(KeyCode.A)){
        running=false;

        }
    if(Input.GetKeyUp(KeyCode.D)){
        running=false;
        }
    if(Input.GetKeyDown(KeyCode.A)){
        running=true;
        }
    if(Input.GetKeyDown(KeyCode.D)){
        running=true;
        }
      if(isJumping==false && isJumping2==false){
          jumping=false;
          }
          else if(isJumping==true || isJumping2==true){
             jumping=true;
        }
    }
        


void Jump(){

            rb.linearVelocity=new Vector2(rb.linearVelocity.x,0);
                        rb.AddForce(new Vector2(0, JumpSpeed),ForceMode2D.Impulse);

}
public void loadlevel(string level)
{
SceneManager.LoadScene(level);
 
}
void OnCollisionEnter2D(Collision2D col)
  {
    if (col.gameObject.layer == 8) 
      {
          isJumping = false;
          isJumping2 = false;
      }
      if (col.gameObject.layer == 17) 
      {
          isJumping = false;
          isJumping2 = false;
      }
    if (col.gameObject.layer == 21) 
      {
          isJumping = false;
          isJumping2 = false;
      }
  } 


}     
    



