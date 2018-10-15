using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    Vector2 start_pos;
	// Use this for initialization
	void Start () {
        start_pos = transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnCollisionEnter2D(Collision2D col)
    {
        //print(on_air);

        if (col.gameObject.name == "Floor")
        {
            transform.position = start_pos;
            print(transform.position);
        }
    }
}
