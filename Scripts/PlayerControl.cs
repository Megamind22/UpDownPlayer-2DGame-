using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{


  [SerializeField] private AudioSource SpeedSound;
  [SerializeField] private AudioSource jumpSound;
  [SerializeField] private AudioSource nextSound;




   public float x_speed=5f;
    private Rigidbody2D rigibody;
    private bool ischeckGround;
    public Transform groundCheckPoint;
    public float groundRaduis;
    public LayerMask groundLayer;// like plank or tree ..any thing can jump on it
    private bool isTouchingGround;
    public Vector3 returnPoint ;//checkpoint
    public DelayScript  delayForplayer ;

    private Animator PlayerAnimation;

    // Start is called before the first frame update
    void Start()
    {
     	rigibody=GetComponent<Rigidbody2D> ();
	PlayerAnimation=GetComponent<Animator> ();
	delayForplayer = FindObjectOfType < DelayScript > () ;
	ischeckGround=false;
    }

    // Update is called once per frame
    void Update()
    {
	
	isTouchingGround=Physics2D.OverlapCircle(groundCheckPoint.position,groundRaduis,groundLayer);
        
	rigibody.velocity=new Vector2(x_speed,rigibody.velocity.y*1.01f);
		
	if (Input.GetKey(KeyCode.UpArrow) && isTouchingGround){
			Physics2D.gravity = new Vector2(0, 9.8f);
			transform.localScale=new Vector2(7f,-8f);//flipbody
			jumpSound.Play();			
	}else if (Input.GetKey(KeyCode.DownArrow) && isTouchingGround){
			Physics2D.gravity = new Vector2(0,-9.8f);
			transform.localScale=new Vector2(7f,8f);
			jumpSound.Play();
			
}
	
	
	PlayerAnimation.SetBool("OnGround",isTouchingGround);
	PlayerAnimation.SetFloat("Speed",x_speed);
    }
  
   void OnTriggerEnter2D(Collider2D other){
	
	string[] strs = { "CameraPoint", "Saw_2", "Saw_21","fallSky","sharpblank","sharpblank2","Spiked Ball","Chain","SpikeTile","Bullet(Clone)"};
	foreach (var item in strs){
      		if (other.gameObject.name ==item){
         		Debug.Log("Triggered");
			Destroy(gameObject);;
			
      }
   }
	 if (other.gameObject.name =="Arrow3"){
		Debug.Log("Speed");
		x_speed=25;
		SpeedSound.Play();
}
	if (other.gameObject.name =="GroundSpeed"){x_speed=9;}//arrow
	if (other.gameObject.name=="Portal_1"){
		delayForplayer.delays_value() ;
		Debug.Log("Triggered");	
	}
	if (other.gameObject.name == "end"){
		x_speed=0;
		nextSound.Play();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
		}
}
}
