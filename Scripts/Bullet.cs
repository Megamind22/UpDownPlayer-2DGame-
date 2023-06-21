using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float fallspeed=3f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D> ();
	rb.velocity=-fallspeed*transform.right;
	Destroy(gameObject,2f);
    }

    // Update is called once per frame
    void Update()
    {
    }

}
