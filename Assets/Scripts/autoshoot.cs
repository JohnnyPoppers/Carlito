using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoshoot : MonoBehaviour {

    public GameObject sphere;
    public GameObject pos1, pos2;
    Vector3 pos;
    bool flip=false;
    Quaternion direction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            setpos();
            direction.eulerAngles = new Vector3(0, -90F, 0);
            Instantiate(sphere, pos, direction);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            setpos();
            direction.eulerAngles = new Vector3(0, -180F, 0);
            Instantiate(sphere, pos, direction);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            setpos();
            direction.eulerAngles = new Vector3(0, 90F, 0);
            Instantiate(sphere, pos, direction);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            setpos();
            direction.eulerAngles = new Vector3(0, 0, 0);
            Instantiate(sphere, pos, direction);
        }

    }

    void setpos()
    {
        if (flip == false)
        {
            pos = pos1.transform.position;
        }
        else
        {
            pos = pos2.transform.position;
        }

        flip = !flip;
    }
}
