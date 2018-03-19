using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalancePlate : MonoBehaviour
{
    public GameObject Ball;
    private Vector3 actual_state, prev_state;
    private BalanceBrain brain;
    public bool Learn = true;
    public bool Load = false;
    public bool Save = true;
    // Use this for initialization
    void Start()
    {
        actual_state = Ball.transform.position;
        prev_state = actual_state;
        if (!Load)
        {
            brain = new BalanceBrain(1000);
        }
        else
        {
            //load trained brain
        }
    }
    //0-increse x,1- dx,2- dy,3 iy
    void Rotate(float[] options)
    {
        //this.transform.Rotate(rotation);
        if (options[0] > 0)
        {
            this.transform.Rotate(new Vector3(options[0], 0, 0));
        }
        if (options[1] > 0)
        {
            this.transform.Rotate(new Vector3(-options[1], 0, 0));
        }
        if (options[2] > 0)
        {
            this.transform.Rotate(new Vector3(0, options[2], 0));
        }
        if (options[3] > 0)
        {
            this.transform.Rotate(new Vector3(0, -options[3], 0));
        }

        //this.transform.eulerAngles= new Vector3(this.transform.eulerAngles.x+rotation.x, this.transform.eulerAngles.y + rotation.y, this.transform.eulerAngles.z + rotation.z);
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
        if (actual_distance < prev_distance)
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
    public float timeforaction = 1;
    public bool canEvaluate = false;
    public bool learning = true;
    // Update is called once per frame
    void Update()
    {
        float[] action=new float[] { 0,0,0,0};
        time += Time.deltaTime;
        //Rotate(new float[] { Random.value, Random.value , Random.value , Random.value });
        //if (time > timeforaction)
        //{
        time = 0;
        //Rotate(new Vector3(0, 0, Random.value));



        if (Input.GetKeyDown("r"))
        {
            learning = !learning;
        }
        if (Input.GetKey("w"))
        {
            action = new float[] { 0, 0, 1, 0 };
        }
        if (Input.GetKey("s"))
        {
            action = new float[] { 0, 0, 0, 1 };
        }
        if (Input.GetKey("a"))
        {
            action = new float[] { 1, 0, 0, 0 };
            
        }
        if (Input.GetKey("d"))
        {
            action = new float[] { 0, 1, 0, 0 };
            
        }


        actual_state = Ball.transform.position;
        if (!learning) { 
            action = brain.DoAction(actual_state, rand);
            //Debug.Log(this.transform.eulerAngles);
           
        }
        Rotate(action);
        Debug.Log(EvaluateAction());
        if (EvaluateAction() && canEvaluate)
        {
            brain.SaveState(actual_state, action);
        }

        prev_state = actual_state;

        //}
    }

    //public void OnApplicationQuit()
    //{
    //    if 
    //}


    private void OnCollisionStay(Collision collision)
    {
        canEvaluate = true;
    }
    void OnCollisionExit(Collision other)
    {
        canEvaluate = false;
    }

}


