using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBalls : MonoBehaviour {
    public GameObject ball;


    GameObject[] balls;


    float time;
	// Use this for initialization
	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        print(time);

	}
}
