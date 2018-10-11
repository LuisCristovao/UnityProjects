using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D rb;
    public int jump_force=1000;
    public int walk_force=200;
    public int help_walk_force=100;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("up"))
        {
            rb.AddForce(new Vector2(0, jump_force));
            print("up arrow key is held down");
        }

        if (Input.GetKeyDown("left"))
        {
            rb.AddForce(new Vector2(-walk_force, help_walk_force));
            print("left arrow key is held down");
        }

        if (Input.GetKeyDown("right"))
        {
            rb.AddForce(new Vector2(walk_force, help_walk_force));
            print("right arrow key is held down");
        }
    }
}
