using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D rb;
    public int jump_force=1000;
    public int walk_force=200;
    public int help_walk_force=100;


    public string jump_key = "up";
    public string left_key = "left";
    public string right_key = "right";

    public GameObject floor;

    private bool on_air;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        on_air = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(jump_key) && !on_air)
        {
            rb.AddForce(new Vector2(0, jump_force));
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            on_air = true;
            //print("up arrow key is held down");
        }

        if (Input.GetKey(left_key))
        {
            if (!on_air)
            {
                rb.AddForce(new Vector2(-walk_force, help_walk_force));
            }
            else
            {
                rb.AddForce(new Vector2(-walk_force, 0));
            }
            
            //print("left arrow key is held down");
        }

        if (Input.GetKey(right_key))
        {
            if (!on_air)
            {
                rb.AddForce(new Vector2(walk_force, help_walk_force));
            }
            else
            {
                rb.AddForce(new Vector2(walk_force, 0));
            }
            //print("right arrow key is held down");
        }
        
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        //print(on_air);
        
        if (col.gameObject.tag== "jumpable")
        {
            on_air = false;

        }
    }
}
