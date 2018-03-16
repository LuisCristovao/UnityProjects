using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droid : MonoBehaviour {
    public Rigidbody m1, m2, m3, m4;
    public GameObject body;
    private Vector3 actual_state, prev_state;
    public GameObject positionCube;
    private Brain brain;
	// Use this for initialization
	void Start () {
        actual_state = body.transform.position;
        prev_state = actual_state;
        brain = new Brain();
	}

    Vector3 Difference(Vector3 pos1,Vector3 pos2)
    {
        float dx, dy, dz;
        dx = Mathf.Abs(pos1.x - pos2.x);
        dy = Mathf.Abs(pos1.y - pos2.y);
        dz = Mathf.Abs(pos1.z - pos2.z);
        return new Vector3(dx, dy, dz);
    }
    /// <summary>
    /// Sees if the droid pos improved in relation to previous state
    /// </summary>
    /// <returns>True if droid did good action else false</returns>
    bool EvaluateAction(float considered_good_improvement_distance)
    {
        Vector3 prev_dif, actual_dif;
        float prev_distance, actual_distance;
        //Previous pos difference
        prev_dif = Difference(prev_state,positionCube.transform.position);
        actual_dif = Difference(actual_state, positionCube.transform.position);

        prev_distance = Mathf.Sqrt(Mathf.Pow(prev_dif.x, 2) + Mathf.Pow(prev_dif.y, 2) + Mathf.Pow(prev_dif.z, 2));
        actual_distance = Mathf.Sqrt(Mathf.Pow(actual_dif.x, 2) + Mathf.Pow(actual_dif.y, 2) + Mathf.Pow(actual_dif.z, 2));
        if (Mathf.Abs(actual_distance-prev_distance)> considered_good_improvement_distance)
        {
            return true;
        }
        else
        {
            return false;
        }
            
    }

	void Move(float[] motor_power)
    {
        m1.AddForce(new Vector3(0, motor_power[0], 0));
        m2.AddForce(new Vector3(0, motor_power[1], 0));
        m3.AddForce(new Vector3(0, motor_power[2], 0));
        m4.AddForce(new Vector3(0, motor_power[3], 0));
    }
	// Update is called once per frame
	void Update () {
        actual_state = Difference(body.transform.position,positionCube.transform.position);

        float[] action = brain.DoAction(actual_state, 0.2f);
        Debug.Log(action[0]);
        Debug.Log(action[1]);
        Debug.Log(action[2]);
        Debug.Log(action[3]);
        Move(action);
        //Debug.Log(actual_state);
        //Debug.Log(prev_state);
        //Debug.Log( EvaluateAction());
        //if drone got near position
        if (EvaluateAction(0.1f))
        {
            brain.SaveState(actual_state, action);
        }


        prev_state = actual_state;
	}
}
