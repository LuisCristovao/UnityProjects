using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour {
    private const float V = 0.02f;
    Vector2 start_pos;
    public Text game_result;
    Rigidbody2D rb;
    public int winning_matches = 10;
    public float timespeed = 1.0f;
    public float bounce = 0.8f;
    public Button restart;
    public Button main_menu;
    public Transform net_position;





    
    private bool game_over;
    // Use this for initialization
    void Start() {
        game_over = false;
        start_pos = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
        

        PhysicsMaterial2D ball_bounciness = new PhysicsMaterial2D("bounce");
        ball_bounciness.bounciness = bounce;
        ball_bounciness.friction = 0.4f;

        gameObject.GetComponent<Collider2D>().sharedMaterial = ball_bounciness;

        restart.onClick.AddListener(delegate { RestartGame(); });
        main_menu.onClick.AddListener(delegate { MainMenu(); });
        restart.gameObject.SetActive(false);
        main_menu.gameObject.SetActive(false);




    }

    // Update is called once per frame
    void Update() {
        Time.timeScale = timespeed;
        //Time.fixedDeltaTime = Time.timeScale*V;
        PhysicsMaterial2D ball_bounciness = new PhysicsMaterial2D("bounce");
        ball_bounciness.bounciness = bounce;
        ball_bounciness.friction = 0.4f;
        gameObject.GetComponent<Collider2D>().sharedMaterial = ball_bounciness;
       


        GameOver();



    }

    void ChangeResult(string team, int point)
    {

        char[] delimiters = { '|' };

        string[] result = game_result.text.Split(delimiters);
        int[] number_result = new int[] { System.Convert.ToInt32(result[0]), System.Convert.ToInt32(result[1]) };
        if (team == "red" || team == "r")
        {
            game_result.text = number_result[0].ToString() + " | " + (number_result[1] + point).ToString();
        }
        if (team == "green" || team == "g")
        {
            game_result.text = (number_result[0] + point).ToString() + " | " + (number_result[1]).ToString();
        }

    }


    void GameOver()
    {
        char[] delimiters = { '|' };

        string[] result = game_result.text.Split(delimiters);
        int[] number_result = new int[] { System.Convert.ToInt32(result[0]), System.Convert.ToInt32(result[1]) };

        if ((number_result[0] >= winning_matches || number_result[1] >= winning_matches) && !game_over )
        {
            timespeed = 0.1f;
            game_over = true;


            restart.gameObject.SetActive(true);
            main_menu.gameObject.SetActive(true);
        }

    }

     void RestartGame()
    {
        game_over = false;
        timespeed = 1;
        transform.position = start_pos;
        rb.velocity = new Vector2(0, 0);
        rb.angularVelocity = 0f;
        game_result.text = "0 | 0";

        restart.gameObject.SetActive(false);
        main_menu.gameObject.SetActive(false);

        GameObject p1 = GameObject.Find("player one");
        p1.transform.position = new Vector2(net_position.position.x + 1, net_position.position.y);
        p1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        p1.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        p1.transform.rotation = new Quaternion(0, 0, 0, 0);

        GameObject p2 = GameObject.Find("player two");
        p2.transform.position = new Vector2(net_position.position.x - 1, net_position.position.y);
        p2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        p2.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        p2.transform.rotation = new Quaternion(0, 0, 0, 0);
    }


    void MainMenu()
    {
         UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        

        if (col.gameObject.name == "team_red_floor")
        {
            transform.position = start_pos;
            rb.velocity = new Vector2(0, 0);
            rb.angularVelocity=0f;
            ChangeResult("g", 1);
           
        }

        if (col.gameObject.name == "team_green_floor")
        {
            transform.position = start_pos;
            rb.velocity = new Vector2(0, 0);
            rb.angularVelocity = 0f;
            ChangeResult("r", 1);
            
        }

      

    }
}
