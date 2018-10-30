using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug : MonoBehaviour {
    public GameObject floor;
    Sprite sprite;
    Sprite obj_sprite;
	// Use this for initialization
	void Start () {
        //sprite = floor.GetComponent<SpriteRenderer>().sprite;
        GameObject obj=Instantiate(floor);
        obj.transform.position = new Vector2(7/2f, -4.5f);
        obj.transform.localScale = new Vector2(7,1);
        obj_sprite = obj.GetComponent<SpriteRenderer>().sprite;
        //Vector2[] obj_vertices = obj_sprite.vertices;

        //obj_vertices[1] = new Vector2(6.5f, 0.5f);// right up corner
        //obj_vertices[2] = new Vector2(6.5f, -0.5f);// right up corner

        //obj_sprite.OverrideGeometry(obj_vertices,obj_sprite.triangles);
    }
	
	// Update is called once per frame
	void Update () {
        foreach (Vector2 v in obj_sprite.vertices)
        {
            print(v);
        }
        //foreach(ushort v in sprite.triangles)
        //{
        //    print(v);
        //}
    }
}
