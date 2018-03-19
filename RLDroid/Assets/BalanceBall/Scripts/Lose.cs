using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour {
    public GameObject ball;
    public Vector3 pos;
    public GameObject plate;
	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        ball.transform.position = new Vector3(pos.x+Random.value*3, pos.y+Random.value*3, pos.z+Random.value*3);
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        plate.transform.eulerAngles = new Vector3(90, 0, 0);
    }
}
