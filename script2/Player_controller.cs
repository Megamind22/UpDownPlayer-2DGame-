using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_controller : MonoBehaviour
{

	[SerializeField] private AudioSource jumpSound;
        [SerializeField] private AudioSource finishSound;

	public float speed = 7f;
  	private Rigidbody2D rigidBody ;
	public Transform  groundCheckpoint ;
       	public float groundCheckRadius = 6f ; 
	public LayerMask groundLayer ; 
	private bool isTouchingGround ; 
	private Animator   playerAnimation ; 
	public Vector3 returnPoint ; // to store the point to return it 
	public delay_manager  delayForplayer ; //for delay
	public nextlevel  text; // for text
 
     // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D> () ; 
	playerAnimation = GetComponent<Animator> () ;
	returnPoint  = transform.position ; 
	delayForplayer = FindObjectOfType < delay_manager > () ;
	text = FindObjectOfType < nextlevel  > () ;
    }

    // Update is called once per frame
    void Update()
    {
		
	isTouchingGround = Physics2D.OverlapCircle(groundCheckpoint.position  , groundCheckRadius , groundLayer  ) ; 
        rigidBody.velocity=new Vector2(speed,rigidBody.velocity.y*1.01f);
		
	if (Input.GetKey(KeyCode.UpArrow) && isTouchingGround){
			Physics2D.gravity = new Vector2(0, 9.8f);
			transform.localScale=new Vector2(4f,-5f);//flipbody
			jumpSound.Play();			
	}else if (Input.GetKey(KeyCode.DownArrow) && isTouchingGround){
			Physics2D.gravity = new Vector2(0,-9.8f);
			transform.localScale=new Vector2(4f,5f);
			jumpSound.Play();
			
}
	
	
	 //for rigth and left move and convert negative value to poistive
	playerAnimation.SetFloat("Speed" , speed );

 	// for show the player on the ground or not 
	playerAnimation.SetBool("OnGround" , isTouchingGround  ) ;

    }


	//for show if touch the border when drop
	
	void OnTriggerEnter2D(Collider2D other){
         
 	if(other.tag == "fulldetected" || other.tag == "pom"  || other.tag == "bat" ){
     	// when drop 
		
	    //transform.position = returnPoint ; old methods
		delayForplayer.delays_value() ; 
	}
	if (other.tag == "Checkpiont"){
	// store the value will return it

		returnPoint = other.transform.position  ; 
	}

	
	if(other.tag == "nextlevel"  ){
		
		  text.text_active() ; 
		 
	 } 
        if(other.tag == "finish" ){
   	  finishSound.Play();
          delayForplayer.end_text();

        }

     	
   	} 



}
 