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
    public Button OK;
    public string decision;

    private Dictionary<string, Button> btns;
    private Ball script;
    private GameObject canvas;
    public GameObject Player;
    public Transform net_position;


    public GameObject InputPrefab;



    void Start()
    {
        script = GameObject.Find("Ball").GetComponent<Ball>();


        canvas = GameObject.Find("Canvas");

        btns = new Dictionary<string, Button>
        {
            { "player vs player", two_players },
            { "team vs team", four_players },
            {"OK", OK }
        };


        //Calls the TaskOnClick/TaskWithParameters method when you click the Button
        Init();
        Hide();
        btns["player vs player"].gameObject.SetActive(true);
        btns["team vs team"].gameObject.SetActive(true);
        //btn1.onClick.AddListener(delegate { Action("player"); });
        //btn2.onClick.AddListener(delegate { Action("team"); });
    }


    void Action(string message)
    {


        if(message == "player vs player")
        {
            decision = message;
            Hide();
            //show player vs player menu
            btns["OK"].gameObject.SetActive(true);

            //Create Inputs
            Dictionary<string, GameObject> input_keys = new Dictionary<string, GameObject>
            {
                {"player_one_jump_key", Instantiate(InputPrefab)},
                {"player_one_right_key", Instantiate(InputPrefab)},
                {"player_one_left_key", Instantiate(InputPrefab)},

                {"player_two_jump_key", Instantiate(InputPrefab)},
                {"player_two_right_key", Instantiate(InputPrefab)},
                {"player_two_left_key", Instantiate(InputPrefab)}

            };
            //GameObject player_one_jump_key=Instantiate(InputPrefab);
            //GameObject player_one_right_key = Instantiate(InputPrefab);
            //GameObject player_one_left_key = Instantiate(InputPrefab);

            //GameObject player_two_jump_key = Instantiate(InputPrefab);
            //GameObject player_two_right_key = Instantiate(InputPrefab);
            //GameObject player_two_left_key = Instantiate(InputPrefab);

            //Turn Canvas GameObject as parent of the inputs
            foreach (KeyValuePair<string, GameObject> entry in input_keys)
            {
                entry.Value.transform.parent = canvas.transform;
            }


            input_keys["player_one_jump_key"].transform.position = new Vector3((Screen.width / 2), (Screen.height / 2) + 6, 0);
            input_keys["player_one_jump_key"].GetComponentInChildren<Text>().text = "player one jump key";
            input_keys["player_one_right_key"].transform.position = new Vector3((Screen.width / 2), (Screen.height / 2) + 4, 0);
            input_keys["player_one_right_key"].GetComponentInChildren<Text>().text = "player one move right key";
            input_keys["player_one_left_key"].transform.position = new Vector3((Screen.width / 2), (Screen.height / 2) + 2, 0);
            input_keys["player_one_left_key"].GetComponentInChildren<Text>().text = "player one move left key";









        }

        if (message == "OK")
        {
            if (decision == "player vs player")
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

                //print(message);
                decision = message;
                Hide();
                script.timespeed = 1;
            }
        }




        //if(message == "player vs player")
        //{
        //    GameObject player_one =Instantiate(Player, new Vector2(net_position.position.x + 1, net_position.position.y), Quaternion.identity);
        //    //player_one.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value,1.0f);
        //    player_one.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.09558821f, 0.09558821f, 1.0f);

        //    GameObject player_two = Instantiate(Player, new Vector2(net_position.position.x - 1, net_position.position.y), Quaternion.identity);
        //    //player_two.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1.0f);
        //    player_two.GetComponent<SpriteRenderer>().color = new Color(0, 0.5367647f, 0.2924442f, 1.0f); ;
        //    player_two.GetComponent<Player>().jump_key = "w";
        //    player_two.GetComponent<Player>().right_key = "d";
        //    player_two.GetComponent<Player>().left_key = "a";

        //    //print(message);
        //    decision = message;
        //    Hide();
        //    script.timespeed = 1;
        //}

        //if (message == "team vs team")
        //{
        //    GameObject player_one = Instantiate(Player, new Vector2(net_position.position.x + 1, net_position.position.y), Quaternion.identity);
        //    //player_one.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value,1.0f);
        //    player_one.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.09558821f, 0.09558821f, 1.0f);

        //    GameObject player_two = Instantiate(Player, new Vector2(net_position.position.x - 1, net_position.position.y), Quaternion.identity);
        //    //player_two.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1.0f);
        //    player_two.GetComponent<SpriteRenderer>().color = new Color(0, 0.5367647f, 0.2924442f, 1.0f); ;
        //    player_two.GetComponent<Player>().jump_key = "w";
        //    player_two.GetComponent<Player>().right_key = "d";
        //    player_two.GetComponent<Player>().left_key = "a";

        //    GameObject player_three = Instantiate(Player, new Vector2(net_position.position.x + 3, net_position.position.y), Quaternion.identity);
        //    //player_two.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1.0f);
        //    player_three.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.6262409f, 0.09411764f, 1.0f); ;
        //    player_three.GetComponent<Player>().jump_key = "o";
        //    player_three.GetComponent<Player>().right_key = "p";
        //    player_three.GetComponent<Player>().left_key = "i";



        //    GameObject player_four = Instantiate(Player, new Vector2(net_position.position.x - 3, net_position.position.y), Quaternion.identity);
        //    //player_two.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1.0f);
        //    player_four.GetComponent<SpriteRenderer>().color = new Color(0.01348342f, 0.7637295f, 0.9528302f, 1.0f); ;
        //    player_four.GetComponent<Player>().jump_key = "b";
        //    player_four.GetComponent<Player>().right_key = "n";
        //    player_four.GetComponent<Player>().left_key = "v";





        //    //print(message);
        //    decision = message;
        //    Hide();
        //    script.timespeed = 1;
        //}

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
