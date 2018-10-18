using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuGame : MonoBehaviour
{

    //public EventSystem e;
    public Button two_players;
    public Button four_players;
    public string decision;

    private Dictionary<string, Button> btns;
    private Ball script;
    public GameObject Player;
    public Transform net_position;


    void Start()
    {
        script = GameObject.Find("Ball").GetComponent<Ball>();




        btns = new Dictionary<string, Button>
        {
            { "player vs player", two_players.GetComponent<Button>() },
            { "team vs team", four_players.GetComponent<Button>() }
        };


        //Calls the TaskOnClick/TaskWithParameters method when you click the Button
        Init();

        //btn1.onClick.AddListener(delegate { Action("player"); });
        //btn2.onClick.AddListener(delegate { Action("team"); });
    }


    void Action(string message)
    {


        if(message == "player vs player")
        {
            GameObject player_one =Instantiate(Player, new Vector2(net_position.position.x + 1, net_position.position.y), Quaternion.identity);
            //player_one.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value,1.0f);
            player_one.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.09558821f, 0.09558821f, 1.0f);

            GameObject player_two = Instantiate(Player, new Vector2(net_position.position.x - 1, net_position.position.y), Quaternion.identity);
            //player_two.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1.0f);
            player_two.GetComponent<SpriteRenderer>().color = new Color(0, 0.5367647f, 0.2924442f, 1.0f); ;
            player_two.GetComponent<Player>().jump_key = "w";
            player_two.GetComponent<Player>().right_key = "d";
            player_two.GetComponent<Player>().left_key = "a";

            //print(message);
            decision = message;
            Hide();
            script.timespeed = 1;
        }

        if (message == "team vs team")
        {
            GameObject player_one = Instantiate(Player, new Vector2(net_position.position.x + 1, net_position.position.y), Quaternion.identity);
            //player_one.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value,1.0f);
            player_one.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.09558821f, 0.09558821f, 1.0f);

            GameObject player_two = Instantiate(Player, new Vector2(net_position.position.x - 1, net_position.position.y), Quaternion.identity);
            //player_two.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1.0f);
            player_two.GetComponent<SpriteRenderer>().color = new Color(0, 0.5367647f, 0.2924442f, 1.0f); ;
            player_two.GetComponent<Player>().jump_key = "w";
            player_two.GetComponent<Player>().right_key = "d";
            player_two.GetComponent<Player>().left_key = "a";

            GameObject player_three = Instantiate(Player, new Vector2(net_position.position.x + 3, net_position.position.y), Quaternion.identity);
            //player_two.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1.0f);
            player_three.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.6262409f, 0.09411764f, 1.0f); ;
            player_three.GetComponent<Player>().jump_key = "o";
            player_three.GetComponent<Player>().right_key = "p";
            player_three.GetComponent<Player>().left_key = "i";



            GameObject player_four = Instantiate(Player, new Vector2(net_position.position.x - 3, net_position.position.y), Quaternion.identity);
            //player_two.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1.0f);
            player_four.GetComponent<SpriteRenderer>().color = new Color(0.01348342f, 0.7637295f, 0.9528302f, 1.0f); ;
            player_four.GetComponent<Player>().jump_key = "b";
            player_four.GetComponent<Player>().right_key = "n";
            player_four.GetComponent<Player>().left_key = "v";





            //print(message);
            decision = message;
            Hide();
            script.timespeed = 1;
        }

    }


    void Hide()
    {
        foreach (KeyValuePair<string, Button> entry in btns)
        {
            // do something with entry.Value or entry.Key
            entry.Value.gameObject.SetActive(false);
        }
    }
    void Init()
    {
        foreach (KeyValuePair<string, Button> entry in btns)
        {
            // do something with entry.Value or entry.Key
            entry.Value.onClick.AddListener(delegate { Action(entry.Key); });
        }
    }
}
