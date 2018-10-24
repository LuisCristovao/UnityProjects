using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D rb;
    public int jump_force=1000;
    public int walk_force=20;
    public int help_walk_force=10;
    public float downwards_speed = 1;

    public string jump_key = "up";
    public string left_key = "left";
    public string right_key = "right";
    float press_time = 0;
    //public GameObject floor;

    private bool on_air;
    //public float timespeed = 1.0f;
    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        on_air = false;
        
    }
	
	// Update is called once per frame
	void Update () {



        if (Input.GetKey(jump_key) && on_air)
        {
            rb.velocity = new Vector2(rb.velocity.x , rb.velocity.y+downwards_speed * Time.timeScale);
            //Debug.Log(rb.velocity);
        }


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
                rb.AddForce(new Vector2(-walk_force * Time.timeScale, help_walk_force*Time.timeScale));
            }
            else
            {
                rb.AddForce(new Vector2(-walk_force * Time.timeScale, 0));
            }
            
            //print("left arrow key is held down");
        }

        if (Input.GetKey(right_key))
        {
            if (!on_air)
            {
                rb.AddForce(new Vector2(walk_force * Time.timeScale, help_walk_force * Time.timeScale));
            }
            else
            {
                rb.AddForce(new Vector2(walk_force * Time.timeScale, 0));
            }
            //print("right arrow key is held down");
        }



        if (on_air)
        {
            rb.velocity = new Vector2(rb.velocity.x , rb.velocity.y-downwards_speed * Time.timeScale);
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
