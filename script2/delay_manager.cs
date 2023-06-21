using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class delay_manager : MonoBehaviour
{ 
 	public float delay ;
	
	public Player_controller  gamePlayer   ; 
	
	public string textvalue ; // value for screen
	public Text textelment ;   
        public Text finish_game ;


    // Start is called before the first frame update
    void Start()
    {
        gamePlayer    = FindObjectOfType < Player_controller  > () ;
	textelment.text  = textvalue  ;
	textelment.gameObject.SetActive(false) ;  
        finish_game.gameObject.SetActive(false) ;
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
	textelment.gameObject.SetActive(true) ; 
	yield return new WaitForSeconds(delay) ;  
	gamePlayer.transform.position   =  gamePlayer.returnPoint  ;
	gamePlayer.gameObject.SetActive(true) ;
	textelment.gameObject.SetActive(false) ;    

	
	}
       
       public void end_text(){
         StartCoroutine ("end") ;
            }
      public IEnumerator end(){
	// to hiden the player for the dela
      finish_game.gameObject.SetActive(true) ;
	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
      yield return new WaitForSeconds(4) ;
     gamePlayer.transform.position = gamePlayer.returnPoint ;
     finish_game.gameObject.SetActive(false) ;
  }


}
