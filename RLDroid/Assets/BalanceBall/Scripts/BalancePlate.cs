using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancePlate : MonoBehaviour {
    public GameObject Ball;
    private Vector3 actual_state, prev_state;
    private BalanceBrain brain;
    public bool Learn = true;
    public bool Load = false;
    public bool Save = true;
    // Use this for initialization
    void Start () {
        actual_state = Ball.transform.position;
        prev_state = actual_state;
        if (!Load)
        {
            brain = new BalanceBrain();
        }
        else
        {
            //load trained brain
        }
    }
	void Rotate(Vector3 rotation)
    {
        this.transform.eulerAngles= new Vector3(this.transform.eulerAngles.x+rotation.x, this.transform.eulerAngles.y + rotation.y, this.transform.eulerAngles.z + rotation.z);
    }
    Vector3 Difference(Vector3 pos1, Vector3 pos2)
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
    bool EvaluateAction()
    {
        Vector3 prev_dif, actual_dif;
        float prev_distance, actual_distance;
        //Previous pos difference
        prev_dif = Difference(prev_state, this.transform.position);
        actual_dif = Difference(actual_state, this.transform.position);

        prev_distance = Mathf.Sqrt(Mathf.Pow(prev_dif.x, 2) + Mathf.Pow(prev_dif.y, 2) + Mathf.Pow(prev_dif.z, 2));
        actual_distance = Mathf.Sqrt(Mathf.Pow(actual_dif.x, 2) + Mathf.Pow(actual_dif.y, 2) + Mathf.Pow(actual_dif.z, 2));
        Debug.Log(Mathf.Abs(actual_distance - prev_distance));
        if (actual_distance<prev_distance)
        {
            return true;
        }
        else
        {
            return false;
        }

    }




    double time = 0;
    public float rand = 0.2f;
	// Update is called once per frame
	void Update () {
        if (Learn)
        {
            //time += Time.deltaTime;
            //if (time > 0.05f)
            //{
                time = 0;
                actual_state = Ball.transform.position;
                Vector3 action = brain.DoAction(actual_state, rand);
                Debug.Log(this.transform.eulerAngles);
                Rotate(action);
                Debug.Log(EvaluateAction());
                if (EvaluateAction())
                {
                    brain.SaveState(actual_state, action);
                }

                prev_state = actual_state;
            //}
        }
        //
        else
        {

        }
	}

    //public void OnApplicationQuit()
    //{
    //    if 
    //}

}
