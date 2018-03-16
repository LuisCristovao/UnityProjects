using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceBrain {
    class Actions
    {
        public Dictionary<Vector3, int> actions;
        public Actions()
        {
            //key-> plate rotation; value-> reward
            actions = new Dictionary<Vector3, int>();
        }
    }
    //key=ball position 
    Dictionary<Vector3, Actions> brain;
    public BalanceBrain()
    {
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
    Vector3 MakeRandomAction()
    {
        float rotx, roty, rotz;
        rotx = Random.value * 2;
        roty = Random.value * 2;
        rotz = Random.value * 2;
        
        return new Vector3 (rotx,roty,rotz);
    }


    //saves state in brain
    public void SaveState(Vector3 state, Vector3 action)
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
            Vector3 nearest_state = new Vector3(0, 0, 0);
            foreach (KeyValuePair<Vector3, Actions> entry in brain)
            {
                // do something with entry.Value or entry.Key
                //measure distance
                float distance = Mathf.Sqrt(Mathf.Pow(entry.Key.x, 2) + Mathf.Pow(entry.Key.y, 2) + Mathf.Pow(entry.Key.z, 2));

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
    Vector3 SelectBestAction(Vector3 state)
    {
        Actions a = brain[state];
        int max = 0, i = 0;
        Vector3 selected_action = new Vector3 (0,0,0);
        foreach (KeyValuePair<Vector3, int> entry in a.actions)
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
    public Vector3 DoAction(Vector3 state, float random_action_percentage)
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
                Vector3 action = SelectBestAction(nearest_state);
                return action;
            }

        }


    }

}
