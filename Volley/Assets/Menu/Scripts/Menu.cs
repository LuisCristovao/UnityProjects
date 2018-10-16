using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public EventSystem e;
	public Button two_players;
	public Button four_players;
    public string decision;



	void Start(){
		Button btn1 = two_players.GetComponent<Button>();
        Button btn2 = four_players.GetComponent<Button>();

        //Calls the TaskOnClick/TaskWithParameters method when you click the Button
        btn1.onClick.AddListener(delegate {Action("player"); });
		btn2.onClick.AddListener(delegate {Action("team"); });
	}
	
	
	void Action(string message){
        print(message);
        decision = message;
	}
	
}
