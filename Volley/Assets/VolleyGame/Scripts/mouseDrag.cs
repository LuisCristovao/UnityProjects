using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script colaborates to the tutorial
//https://www.youtube.com/watch?v=pK1CbnE2VsI

public class mouseDrag : MonoBehaviour
{

    float distance = 10;
    Vector3 objectPos;
    private void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.position = objectPos;

       // Debug.Log("MousePos:"+mousePos);
        //Debug.Log("objectPos:"+objectPos);
        //Debug.Log("transform:"+transform.position);
    }


    void OnMouseUp()
    {
        //Debug.Log("objectPos:" + objectPos);
    }

}