using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    Vector2 start_pos;
    public Text game_result;
    Rigidbody2D rb;
    public int winning_matches = 10;
    public float timespeed = 1.0f;
	// Use this for initialization
	void Start () {
        start_pos = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = timespeed;
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

        if (col.gameObject.name == "team_red_floor")
        {
            transform.position = start_pos;
            rb.velocity = new Vector2(0, 0);
            ChangeResult("g", 1);
            //print(transform.position);
        }

        if (col.gameObject.name == "team_green_floor")
        {
            transform.position = start_pos;
            rb.velocity = new Vector2(0, 0);
            ChangeResult("r", 1);
            //print(transform.position);
        }



    }
}
