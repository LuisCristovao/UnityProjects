using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain  {

    class Actions
    {
        public Dictionary<float[], int> actions;
        public Actions()
        {
            //float[] shows motor power [m1,m2,m3,m4] the int is the reward associated
            actions= new Dictionary<float[], int>();
        }
    }

    Dictionary<Vector3, Actions> brain;
    // Use this for initialization
    public Brain () {
        //float[] is going to have difference in droid pos and pos
        //float[]=[dx,dy,dz]
        //Action has a dicionary of actions with their rewards
        //meaning for each state there is a list of actions, each one width their reward
       brain = new Dictionary<Vector3, Actions>(); 
	}

    Vector3 Difference(Vector3 pos1, Vector3 pos2)
    {
        float dx, dy, dz;
        dx = Mathf.Abs(pos1.x - pos2.x);
        dy = Mathf.Abs(pos1.y - pos2.y);
        dz = Mathf.Abs(pos1.z - pos2.z);
        return new Vector3(dx, dy, dz);
    }


    //Make random action
    float[] MakeRandomAction()
    {
        float p1, p2, p3, p4;
        p1 = Random.value * 10+5;
        p2 = Random.value * 10 + 5;
        p3 = Random.value * 10+ 5;
        p4 = Random.value * 10 + 5;

        return new float[] { p1, p2, p3, p4 };
    }


    //saves state in brain
    public void SaveState(Vector3 state,float[] action)
    {
        //already contains state
        if (brain.ContainsKey(state))
        {
            Actions actions = brain[state];
            //See if action is already saved!
            if (actions.actions.ContainsKey(action))
            {
                //increase reward value from action
                int reward = actions.actions[action];
                reward++;
                actions.actions[action] = reward;
            }
            else
            {
                //add new action
                actions.actions[action] = 1;
            }
        }
        else
        {
            Actions actions = new Actions();
            actions.actions.Add(action, 1);
            brain.Add(state, actions);
        }
    }
    //returns nearest state in brain from received state
    Vector3 SelectNearestState(Vector3 state)
    {
        //see if there is exactly the same state
        if (brain.ContainsKey(state))
        {
            return state;
        }
        //Select nearest "neighbour"
        else
        {
            float min_distance = Mathf.Infinity;
            //Probably need to change this
            Vector3 nearest_state=new Vector3(0,0,0);
            foreach (KeyValuePair<Vector3, Actions> entry in brain)
            {
                // do something with entry.Value or entry.Key
                //measure distance
                float distance = Mathf.Sqrt(Mathf.Pow(entry.Key.x,2) + Mathf.Pow(entry.Key.y, 2) + Mathf.Pow(entry.Key.z, 2));
                
                //see the lowest distance
                if (distance < min_distance)
                {
                    min_distance = distance;
                    nearest_state = entry.Key;
                }
            }
            return nearest_state;
        }
    }
    //select action with best reward
    float[] SelectBestAction(Vector3 state)
    {
        Actions a = brain[state];
        int max=0,i=0;
        float[] selected_action=new float[] { 0,0,0,0};
        foreach(KeyValuePair<float[],int> entry in a.actions)
        {
            if (i == 0)
            {
                max = entry.Value;
                i++;
                selected_action = entry.Key;
            }
            else
            {
                if (entry.Value > max)
                {
                    max = entry.Value;
                    selected_action = entry.Key;
                }
            }
        }
        return selected_action;
    }
    //For some state do action
    //state is the difference vector between droid and position
    public float[] DoAction(Vector3 state,float random_action_percentage)
    {
        //if dictionary is empty
        if (brain.Count == 0)
        {
            //Random Play
            return MakeRandomAction();
        }
        else
        {
            float n = Random.value;

            if (n <= random_action_percentage)
            {
                return MakeRandomAction();
            }
            else
            {
                Vector3 nearest_state = SelectNearestState(state);
                float[] action = SelectBestAction(nearest_state);
                return action;
            }

        }
        

    }


	
}
