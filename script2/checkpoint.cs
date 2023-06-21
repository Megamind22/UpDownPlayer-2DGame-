using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
	public Sprite onfireflag;
	public Sprite offfireflag; 
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

 	checkpointSpriteRenderer.sprite  =   offfireflag ;
	checkpointSpriteReached   = true ; 
 
 	
	}

 


 	}
        
    
}
