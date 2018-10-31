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
    private Dictionary<string, GameObject> input_keys;
    private Rect normal_mode, crazy_mode;


    public GameObject Player;
    public Transform net_position;


    public GameObject InputPrefab;
    public GameObject toggle_prefab;


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


    private void Update()
    {
        
    }



    void Action(string message)
    {


        if (message == "player vs player")
        {
            decision = message;
            Hide();
            //show player vs player menu
            btns["OK"].gameObject.SetActive(true);


            //Create Inputs
            input_keys = new Dictionary<string, GameObject>
            {
                {"player_one_jump_key", Instantiate(InputPrefab)},
                {"player_one_right_key", Instantiate(InputPrefab)},
                {"player_one_left_key", Instantiate(InputPrefab)},

                {"player_two_jump_key", Instantiate(InputPrefab)},
                {"player_two_right_key", Instantiate(InputPrefab)},
                {"player_two_left_key", Instantiate(InputPrefab)},

                {"number_of_matches", Instantiate(InputPrefab)},
                {"crazy_mode",Instantiate(toggle_prefab)}

            };

            //Turn Canvas GameObject as parent of the inputs
            foreach (KeyValuePair<string, GameObject> entry in input_keys)
            {
                entry.Value.transform.parent = canvas.transform;
            }


            input_keys["number_of_matches"].transform.position = new Vector2(OK.transform.position.x, OK.transform.position.y + 50);
            input_keys["number_of_matches"].GetComponentInChildren<Text>().text = "Number of Matches";
            input_keys["number_of_matches"].GetComponentInChildren<InputField>().text = "3";



            input_keys["crazy_mode"].transform.position = new Vector2(input_keys["number_of_matches"].transform.position.x, input_keys["number_of_matches"].transform.position.y + 100);
            input_keys["crazy_mode"].GetComponentInChildren<Text>().text = "Crazy Mode";
            input_keys["crazy_mode"].GetComponent<Toggle>().isOn= false;


            input_keys["player_two_jump_key"].transform.position = new Vector3((Screen.width / 2) - 350, (Screen.height / 2) + 220, 0);
            input_keys["player_two_jump_key"].GetComponentInChildren<Text>().text = "player two jump key";
            input_keys["player_two_jump_key"].GetComponentInChildren<InputField>().text = "w";

            input_keys["player_two_right_key"].transform.position = new Vector3((Screen.width / 2) - 350, (Screen.height / 2) + 150, 0);
            input_keys["player_two_right_key"].GetComponentInChildren<Text>().text = "player two right key";
            input_keys["player_two_right_key"].GetComponentInChildren<InputField>().text = "d";

            input_keys["player_two_left_key"].transform.position = new Vector3((Screen.width / 2) - 350, (Screen.height / 2) + 80, 0);
            input_keys["player_two_left_key"].GetComponentInChildren<Text>().text = "player two left key";
            input_keys["player_two_left_key"].GetComponentInChildren<InputField>().text = "a";



            input_keys["player_one_jump_key"].transform.position = new Vector3((Screen.width / 2) + 350, (Screen.height / 2) + 220, 0);
            input_keys["player_one_jump_key"].GetComponentInChildren<Text>().text = "player one jump key";
            input_keys["player_one_jump_key"].GetComponentInChildren<InputField>().text = "up";

            input_keys["player_one_right_key"].transform.position = new Vector3((Screen.width / 2) + 350, (Screen.height / 2) + 150, 0);
            input_keys["player_one_right_key"].GetComponentInChildren<Text>().text = "player one right key";
            input_keys["player_one_right_key"].GetComponentInChildren<InputField>().text = "right";


            input_keys["player_one_left_key"].transform.position = new Vector3((Screen.width / 2) + 350, (Screen.height / 2) + 80, 0);
            input_keys["player_one_left_key"].GetComponentInChildren<Text>().text = "player one left key";
            input_keys["player_one_left_key"].GetComponentInChildren<InputField>().text = "left";

           


        }


        if (message == "team vs team")
        {
            decision = message;
            Hide();
            //show player vs player menu
            btns["OK"].gameObject.SetActive(true);


            //Create Inputs
            input_keys = new Dictionary<string, GameObject>
            {
                {"player_one_jump_key", Instantiate(InputPrefab)},
                {"player_one_right_key", Instantiate(InputPrefab)},
                {"player_one_left_key", Instantiate(InputPrefab)},

                {"player_two_jump_key", Instantiate(InputPrefab)},
                {"player_two_right_key", Instantiate(InputPrefab)},
                {"player_two_left_key", Instantiate(InputPrefab)},

                {"player_three_jump_key", Instantiate(InputPrefab)},
                {"player_three_right_key", Instantiate(InputPrefab)},
                {"player_three_left_key", Instantiate(InputPrefab)},

                {"player_four_jump_key", Instantiate(InputPrefab)},
                {"player_four_right_key", Instantiate(InputPrefab)},
                {"player_four_left_key", Instantiate(InputPrefab)},

                {"number_of_matches", Instantiate(InputPrefab)},
                {"crazy_mode",Instantiate(toggle_prefab)}

            };

            //Turn Canvas GameObject as parent of the inputs
            foreach (KeyValuePair<string, GameObject> entry in input_keys)
            {
                entry.Value.transform.parent = canvas.transform;
            }


            input_keys["number_of_matches"].transform.position = new Vector2(OK.transform.position.x,OK.transform.position.y+ 50);
            input_keys["number_of_matches"].GetComponentInChildren<Text>().text = "Number of Matches";
            input_keys["number_of_matches"].GetComponentInChildren<InputField>().text = "3";


            input_keys["crazy_mode"].transform.position = new Vector2(input_keys["number_of_matches"].transform.position.x, input_keys["number_of_matches"].transform.position.y + 100);
            input_keys["crazy_mode"].GetComponentInChildren<Text>().text = "Crazy Mode";
            input_keys["crazy_mode"].GetComponent<Toggle>().isOn = false;



            input_keys["player_two_jump_key"].transform.position = new Vector3((Screen.width / 2) - 350, (Screen.height / 2) + 220, 0);
            input_keys["player_two_jump_key"].GetComponentInChildren<Text>().text = "player two jump key";
            input_keys["player_two_jump_key"].GetComponentInChildren<InputField>().text = "w";

            input_keys["player_two_right_key"].transform.position = new Vector3((Screen.width / 2) - 350, (Screen.height / 2) + 150, 0);
            input_keys["player_two_right_key"].GetComponentInChildren<Text>().text = "player two right key";
            input_keys["player_two_right_key"].GetComponentInChildren<InputField>().text = "d";

            input_keys["player_two_left_key"].transform.position = new Vector3((Screen.width / 2) - 350, (Screen.height / 2) + 80, 0);
            input_keys["player_two_left_key"].GetComponentInChildren<Text>().text = "player two left key";
            input_keys["player_two_left_key"].GetComponentInChildren<InputField>().text = "a";



            input_keys["player_one_jump_key"].transform.position = new Vector3((Screen.width / 2) + 350, (Screen.height / 2) + 220, 0);
            input_keys["player_one_jump_key"].GetComponentInChildren<Text>().text = "player one jump key";
            input_keys["player_one_jump_key"].GetComponentInChildren<InputField>().text = "up";

            input_keys["player_one_right_key"].transform.position = new Vector3((Screen.width / 2) + 350, (Screen.height / 2) + 150, 0);
            input_keys["player_one_right_key"].GetComponentInChildren<Text>().text = "player one right key";
            input_keys["player_one_right_key"].GetComponentInChildren<InputField>().text = "right";


            input_keys["player_one_left_key"].transform.position = new Vector3((Screen.width / 2) + 350, (Screen.height / 2) + 80, 0);
            input_keys["player_one_left_key"].GetComponentInChildren<Text>().text = "player one left key";
            input_keys["player_one_left_key"].GetComponentInChildren<InputField>().text = "left";


            //---------------------------------------
            input_keys["player_four_jump_key"].transform.position = new Vector3((Screen.width / 2) - 350, (Screen.height / 2) - 220, 0);
            input_keys["player_four_jump_key"].GetComponentInChildren<Text>().text = "player four jump key";
            input_keys["player_four_jump_key"].GetComponentInChildren<InputField>().text = "b";

            input_keys["player_four_right_key"].transform.position = new Vector3((Screen.width / 2) - 350, (Screen.height / 2) - 150, 0);
            input_keys["player_four_right_key"].GetComponentInChildren<Text>().text = "player four right key";
            input_keys["player_four_right_key"].GetComponentInChildren<InputField>().text = "n";

            input_keys["player_four_left_key"].transform.position = new Vector3((Screen.width / 2) - 350, (Screen.height / 2) - 80, 0);
            input_keys["player_four_left_key"].GetComponentInChildren<Text>().text = "player four left key";
            input_keys["player_four_left_key"].GetComponentInChildren<InputField>().text = "v";


            input_keys["player_three_jump_key"].transform.position = new Vector3((Screen.width / 2) + 350, (Screen.height / 2) - 220, 0);
            input_keys["player_three_jump_key"].GetComponentInChildren<Text>().text = "player three jump key";
            input_keys["player_three_jump_key"].GetComponentInChildren<InputField>().text = "o";

            input_keys["player_three_right_key"].transform.position = new Vector3((Screen.width / 2) + 350, (Screen.height / 2) - 150, 0);
            input_keys["player_three_right_key"].GetComponentInChildren<Text>().text = "player three right key";
            input_keys["player_three_right_key"].GetComponentInChildren<InputField>().text = "p";

            input_keys["player_three_left_key"].transform.position = new Vector3((Screen.width / 2) + 350, (Screen.height / 2) - 80, 0);
            input_keys["player_three_left_key"].GetComponentInChildren<Text>().text = "player three left key";
            input_keys["player_three_left_key"].GetComponentInChildren<InputField>().text = "i";







        }




        if (message == "OK")
        {
            if (decision == "player vs player")
            {
                GameObject player_one = Instantiate(Player, new Vector2(net_position.position.x + 1, net_position.position.y), Quaternion.identity);
                player_one.name = "player one";
                //player_one.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value,1.0f);
                player_one.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.09558821f, 0.09558821f, 1.0f);
                player_one.GetComponent<Player>().jump_key = input_keys["player_one_jump_key"].GetComponentInChildren<InputField>().text;
                player_one.GetComponent<Player>().right_key = input_keys["player_one_right_key"].GetComponentInChildren<InputField>().text;
                player_one.GetComponent<Player>().left_key = input_keys["player_one_left_key"].GetComponentInChildren<InputField>().text;

                GameObject player_two = Instantiate(Player, new Vector2(net_position.position.x - 1, net_position.position.y), Quaternion.identity);
                player_two.name = "player two";
                //player_two.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1.0f);
                player_two.GetComponent<SpriteRenderer>().color = new Color(0, 0.5367647f, 0.2924442f, 1.0f); ;
                player_two.GetComponent<Player>().jump_key = input_keys["player_two_jump_key"].GetComponentInChildren<InputField>().text;
                player_two.GetComponent<Player>().right_key = input_keys["player_two_right_key"].GetComponentInChildren<InputField>().text;
                player_two.GetComponent<Player>().left_key = input_keys["player_two_left_key"].GetComponentInChildren<InputField>().text;


                
            }



            if (decision == "team vs team")
            {
                GameObject player_one = Instantiate(Player, new Vector2(net_position.position.x + 1, net_position.position.y), Quaternion.identity);
                player_one.name = "player one";
                //player_one.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value,1.0f);
                player_one.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.09558821f, 0.09558821f, 1.0f);
                player_one.GetComponent<Player>().jump_key = input_keys["player_one_jump_key"].GetComponentInChildren<InputField>().text;
                player_one.GetComponent<Player>().right_key = input_keys["player_one_right_key"].GetComponentInChildren<InputField>().text;
                player_one.GetComponent<Player>().left_key = input_keys["player_one_left_key"].GetComponentInChildren<InputField>().text;

                GameObject player_two = Instantiate(Player, new Vector2(net_position.position.x - 1, net_position.position.y), Quaternion.identity);
                player_two.name = "player two";
                //player_two.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1.0f);
                player_two.GetComponent<SpriteRenderer>().color = new Color(0, 0.5367647f, 0.2924442f, 1.0f); ;
                player_two.GetComponent<Player>().jump_key = input_keys["player_two_jump_key"].GetComponentInChildren<InputField>().text;
                player_two.GetComponent<Player>().right_key = input_keys["player_two_right_key"].GetComponentInChildren<InputField>().text;
                player_two.GetComponent<Player>().left_key = input_keys["player_two_left_key"].GetComponentInChildren<InputField>().text;


                //--------------------------------------

                GameObject player_three = Instantiate(Player, new Vector2(net_position.position.x + 3, net_position.position.y), Quaternion.identity);
                player_three.name = "player three";
                //player_three.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1.0f);
                player_three.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.6262409f, 0.09411764f, 1.0f);
                player_three.GetComponent<Player>().jump_key = input_keys["player_three_jump_key"].GetComponentInChildren<InputField>().text;
                player_three.GetComponent<Player>().right_key = input_keys["player_three_right_key"].GetComponentInChildren<InputField>().text;
                player_three.GetComponent<Player>().left_key = input_keys["player_three_left_key"].GetComponentInChildren<InputField>().text;


                GameObject player_four = Instantiate(Player, new Vector2(net_position.position.x - 3, net_position.position.y), Quaternion.identity);
                player_four.name = "player four";
                //player_four.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1.0f);
                player_four.GetComponent<SpriteRenderer>().color = new Color(0.01348342f, 0.7637295f, 0.9528302f, 1.0f);
                player_four.GetComponent<Player>().jump_key = input_keys["player_four_jump_key"].GetComponentInChildren<InputField>().text;
                player_four.GetComponent<Player>().right_key = input_keys["player_four_right_key"].GetComponentInChildren<InputField>().text;
                player_four.GetComponent<Player>().left_key = input_keys["player_four_left_key"].GetComponentInChildren<InputField>().text;




                
            }



            script.winning_matches = int.Parse( input_keys["number_of_matches"].GetComponentInChildren<InputField>().text);
            //if crazy mode
            if (input_keys["crazy_mode"].GetComponent<Toggle>().isOn)
            {
                script.crazy_mode = true;
            }
            else
            {
                script.crazy_mode = false;
            }

            //Destroy inputs created
            foreach (KeyValuePair<string, GameObject> entry in input_keys)
            {
                Destroy(entry.Value);
            }

            

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
