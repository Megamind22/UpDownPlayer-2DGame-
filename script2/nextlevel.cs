using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nextlevel : MonoBehaviour
{

	public string textvalue ; // value for screen
	public Text textelment ;
	public float delay ;


    // Start is called before the first frame update
    void Start()
    {

        textelment.text  = textvalue  ;
	textelment.gameObject.SetActive(false) ;
    }

    // Update is called once per frame
    void Update()
    {
           
    }




	public void text_active(){

		StartCoroutine ("delay_Coroutine")  ;
	}

	public IEnumerator delay_Coroutine(){
	
	textelment.gameObject.SetActive(true) ; 
	yield return new WaitForSeconds(delay) ;  
	textelment.gameObject.SetActive(false) ;    
	
	}

	



}



