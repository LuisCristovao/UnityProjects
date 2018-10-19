using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
    private const float V = 0.02f;
    Vector2 start_pos;
    public Text game_result;
    Rigidbody2D rb;
    public int winning_matches = 10;
    public float timespeed = 1.0f;
    public float bounce = 2f;

    private float[] prev_velocity;

	// Use this for initialization
	void Start () {
        start_pos = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
        prev_velocity = new float[2] { rb.velocity.x, rb.velocity.y };
        
    }
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = timespeed;
        //Time.fixedDeltaTime = Time.timeScale*V;

        prev_velocity[0] = rb.velocity.x;
        prev_velocity[1] = rb.velocity.y;
    }

    void ChangeResult(string team,int point)
    {
        
        char[] delimiters = { '|' };
        
        string[] result = game_result.text.Split(delimiters);
        int[] number_result = new int[] { System.Convert.ToInt32(result[0]), System.Convert.ToInt32(result[1]) };
        if (team == "red" || team == "r")
        {
            game_result.text = number_result[0].ToString() + " | " + (number_result[1]+point).ToString();
        }
        if (team == "green"|| team=="g")
        {
            game_result.text = (number_result[0] + point).ToString() + " | " + (number_result[1]).ToString();
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //print(on_air);
        bool touch_floor = false;

        if (col.gameObject.name == "team_red_floor")
        {
            transform.position = start_pos;
            rb.velocity = new Vector2(0, 0);
            rb.angularVelocity=0f;
            ChangeResult("g", 1);
            touch_floor = true;
            //print(transform.position);
        }

        if (col.gameObject.name == "team_green_floor")
        {
            transform.position = start_pos;
            rb.velocity = new Vector2(0, 0);
            rb.angularVelocity = 0f;
            ChangeResult("r", 1);
            touch_floor = true;
            //print(transform.position);
        }

        if (/*col.gameObject.name!="PlayerOne(Clone)" &&*/ !touch_floor)
        {
            //print(prev_velocity[1]);
            float diffx=(col.transform.position.x-transform.position.x);
            float diffy=(col.transform.position.y - transform.position.y);

            print(diffx);

            //if ball collided with an object above it
            if (Mathf.Floor(diffx) ==  0)
            {
                rb.AddForce(new Vector2(0, -prev_velocity[1] * bounce));
            }
            //if ball collided with an object on the side
            if (Mathf.Floor(diffx) != 0)
            {
                rb.AddForce(new Vector2(-prev_velocity[0] * bounce, 0));
            }


        }

    }
}
