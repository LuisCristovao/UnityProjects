using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuGame : MonoBehaviour {

    //public EventSystem e;
	public Button two_players;
    public Button four_players;
    public string decision;

    private Dictionary<string, Button> btns;
    private Ball script;



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
        print(message);
        decision = message;
        Hide();
        script.timespeed = 1;

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
        foreach(KeyValuePair<string, Button> entry in btns)
        {
            // do something with entry.Value or entry.Key
            entry.Value.onClick.AddListener(delegate { Action(entry.Key); });
        }
    }
}
