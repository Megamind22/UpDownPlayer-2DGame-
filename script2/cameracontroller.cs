using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
	public GameObject player ; 
	public float offset ; // show long view
	private Vector3 playerpoistion ; 
	public float offsetSmoothing ; // time to take form move convert from rigth to left  
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	// vector3 for x y z
	//follow the player for x and not change of y and z 
        //transform.position = new Vector3(player.transform.position.x , transform.position.y  , transform.position.z) ;


	playerpoistion = new Vector3(player.transform.position.x , transform.position.y  , transform.position.z) ;
 		
	//rigth move
	if(player.transform.localScale.x  > 0f ){
	playerpoistion = new Vector3(playerpoistion.x + offset, playerpoistion.y  , playerpoistion.z) ;
	}

	else{
	playerpoistion = new Vector3(playerpoistion.x - offset, playerpoistion.y  , playerpoistion.z) ;
	}

        
	//transform.position = playerpoistion  ; 

	transform.position = Vector3.Lerp (transform.position , playerpoistion   , offsetSmoothing *Time.deltaTime ) ; 
	

	
    }
}
