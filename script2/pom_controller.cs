using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pom_controller : MonoBehaviour
{
	private SpriteRenderer checkpointSpriteRenderer  ; 
	public bool checkpointSpriteReached  ;
	
    // Start is called before the first frame update
    void Start()
    {
        checkpointSpriteRenderer   = GetComponent <SpriteRenderer> () ; 
    }

    // Update is called once per frame
    void Update()
    {
 	
    }
 	// to check if player reatch this point  and covert flag 
	void OnTriggerEnter2D(Collider2D other){
 	
	if(other.tag == "player"){

 	checkpointSpriteRenderer.gameObject.SetActive(true) ; 
 	
	}

	   
	
 	}
        
    
}
