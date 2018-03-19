using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using System;

//[Serializable]
public class BalanceBrain
{
    // [Serializable]
    public class Memory
    {
        public Vector3 ball_pos, plate_angles;
        public float[] action;
        public int memory_colections;
        public Memory(Vector3 ball_state, float[] action)
        {
            this.ball_pos = ball_state;
            //this.plate_angles = plate_state;
            this.action = action;
            this.memory_colections = 0;
        }
    }
    //key=ball position 
    public List<Memory> brain;
    int memory_capacity, actual_brain_capacity = 0;
    public BalanceBrain(int brain_size)
    {
        brain = new List<Memory>();
        memory_capacity = brain_size;

    }

    Vector3 Difference(Vector3 pos1, Vector3 pos2)
    {
        float dx, dy, dz;
        dx = Mathf.Abs(pos1.x - pos2.x);
        dy = Mathf.Abs(pos1.y - pos2.y);
        dz = Mathf.Abs(pos1.z - pos2.z);
        return new Vector3(dx, dy, dz);
    }
    Vector3 LocalAverege(Vector3 one, Vector3 two)
    {

        float x_average, y_average, z_average;
        x_average = (one.x + two.x) / 2;
        y_average = (one.y + two.y) / 2;
        z_average = (one.z + two.z) / 2;

        return new Vector3(x_average, y_average, z_average);
    }
    float[] LocalAverege2(float[] one, float[] two)
    {

        float op1_average, op2_average, op3_average, op4_average;
        op1_average = (one[0] + two[0]) / 2;
        op2_average = (one[1] + two[1]) / 2;
        op3_average = (one[2] + two[2]) / 2;
        op4_average = (one[3] + two[3]) / 2;
        return new float[] { op1_average, op2_average, op3_average, op4_average };
    }

    //Make random action
    float[] MakeRandomAction()
    {
        float op1, op2, op3,op4;
        op1 = Random.value * 1;
        op2 = Random.value * 1;
        op3 = Random.value * 1;
        op4 = Random.value * 1;
        return new float[] { op1,op2,op3,op4};
    }


    //saves state in brain
    public void SaveState(Vector3 ball_state, float[] action)
    {
        //if brain is not full
        //fill it
        if (actual_brain_capacity < memory_capacity)
        {
            brain.Add(new Memory(ball_state, action));
        }
        //find nearest neigbour and place it there by making an averege of results
        //in that position
        else
        {
            int near_state_index = SelectNearestState(ball_state);
            Memory m = brain[near_state_index];
            //Make average of the new knowledge with old one
            m.ball_pos = LocalAverege(m.ball_pos, ball_state);
            m.action = LocalAverege2(m.action, action);
        }

    }
    //returns nearest state in brain from received state
    int SelectNearestState(Vector3 state)
    {

        float min_distance = Mathf.Infinity;
        //Probably need to change this
        int nearest_state = 0;
        for (int i = 0; i < brain.Count; i++)
        {
            Memory entry = brain[i];
            //difference between states
            Vector3 dif_vector = Difference(state, entry.ball_pos);
            //measure distance of dif_vetor
            float distance = Mathf.Sqrt(Mathf.Pow(dif_vector.x, 2) + Mathf.Pow(dif_vector.y, 2) + Mathf.Pow(dif_vector.z, 2));
            //find lowest distance, meaning nearest neighbour
            if (min_distance > distance)
            {
                min_distance = distance;
                nearest_state = i;

            }
        }
        return nearest_state;

    }
    //select action with best reward
    float[] SelectBestAction(Vector3 state)
    {
        //if brain empty
        if (brain.Count == 0)
        {
            return MakeRandomAction();
        }
        //Select nearest memory
        else
        {
            int nearest_memory_index = SelectNearestState(state);
            Memory m = brain[nearest_memory_index];
            return m.action;
        }

    }
    //For some state do action
    //state is the difference vector between droid and position
    public float[] DoAction(Vector3 state, float random_action_percentage)
    {
        //if dictionary is empty

        float n = Random.value;

        if (n <= random_action_percentage)
        {
            return MakeRandomAction();
        }
        else
        {

            float[] action = SelectBestAction(state);
            return action;
        }

    }


}


