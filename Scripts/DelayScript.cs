using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayScript : MonoBehaviour
{ 
 	public float delay ;
	
	public PlayerControl  gamePlayer   ; 
	
	//public string textvalue ; // value for screen
	//public Text textelment ;   


    // Start is called before the first frame update
    void Start()
    {
        gamePlayer    = FindObjectOfType < PlayerControl  > () ;
	//textelment.text  = textvalue  ;
	//textelment.gameObject.SetActive(false) ;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void delays_value(){
	 
 	StartCoroutine ("delay_Coroutine")  ;  
	
	}
	
	// for delay the part of code routine
	public IEnumerator delay_Coroutine(){
	
	// to hiden the player for the delay
	gamePlayer.gameObject.SetActive(false) ;
	//textelment.gameObject.SetActive(true) ; 
	yield return new WaitForSeconds(delay) ;  
	gamePlayer.transform.position   =  gamePlayer.returnPoint  ;
	gamePlayer.gameObject.SetActive(true) ;
	//textelment.gameObject.SetActive(false) ;    

	
	}
}