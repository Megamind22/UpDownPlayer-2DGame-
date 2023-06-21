using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform firepoint;
    public GameObject Bullet;
    float TimeBetween;
    public float StartTimeBetween;
    // Start is called before the first frame update
    void Start()
    {
       TimeBetween=StartTimeBetween;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeBetween <=0 ){
	Instantiate(Bullet,firepoint.position,firepoint.rotation);
	TimeBetween=StartTimeBetween;
	}else{TimeBetween-=Time.deltaTime;}
    }
}
