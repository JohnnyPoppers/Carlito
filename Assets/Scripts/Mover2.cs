using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover2 : MonoBehaviour
{

    Animator Carlito_anim;
    public GameObject Carlito;
    Vector3 orientation;
    Quaternion ori;
    public float speed = 0.2F;

    bool up = false, down = false, left = false, right = false;
    // Use this for initialization
    void Start()
    {
        Carlito_anim = Carlito.transform.GetChild(0).GetComponent<Animator>();
        ori = new Quaternion();
        ori.eulerAngles = new Vector3(0, 0, 0);
        Carlito_anim.speed = 1.5F;
        
    }

    public void setUP()
    {
        up = !up;
    }
    public void setDOWN()
    {
        down = !down;
    }
    public void setLEFT()
    {
        left = !left;
    }
    public void seRIGHT()
    {
        right = !right;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || up || down || left || right)
        {
            ori.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.Z) && (Input.GetKey(KeyCode.D)))
        {
            transform.Translate(new Vector3(-speed/1.41F, 0, speed / 1.41F));
            ori.eulerAngles += new Vector3(0, -45, 0);
            Carlito_anim.SetBool("walk", true);
            Carlito_anim.SetBool("shoot", true);

        }
        else if (Input.GetKey(KeyCode.Z) && (Input.GetKey(KeyCode.Q)))
        {
            transform.Translate(new Vector3(-speed / 1.41F, 0, -speed / 1.41F));
            ori.eulerAngles += new Vector3(0, -135, 0);
            Carlito_anim.SetBool("walk", true);
            Carlito_anim.SetBool("shoot", true);



        }
        else if (Input.GetKey(KeyCode.Z) || up)
        {
            transform.Translate(new Vector3(-speed,0, 0));
            ori.eulerAngles += new Vector3(0, -90, 0);
            Carlito_anim.SetBool("walk", true);
            Carlito_anim.SetBool("shoot", true);


        }

        else if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.S)))
        {
            transform.Translate(new Vector3(speed / 1.41F, 0, speed / 1.41F));
            ori.eulerAngles += new Vector3(0, 45, 0);
            Carlito_anim.SetBool("walk", true);
            Carlito_anim.SetBool("shoot", true);


        }
        else if (Input.GetKey(KeyCode.D) || right)
        {
            transform.Translate(new Vector3(0, 0, speed));
            ori.eulerAngles += new Vector3(0, 0, 0);
            Carlito_anim.SetBool("walk", true);
            Carlito_anim.SetBool("shoot", true);


        }
        else if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.Q)))
        {
            transform.Translate(new Vector3(speed / 1.41F, 0, -speed / 1.41F));
            ori.eulerAngles += new Vector3(0, 135, 0);
            Carlito_anim.SetBool("walk", true);
            Carlito_anim.SetBool("shoot", true);


        }
        else if (Input.GetKey(KeyCode.S) || down)
        {
            transform.Translate(new Vector3(speed, 0, 0));
            ori.eulerAngles += new Vector3(0, 90, 0);
            Carlito_anim.SetBool("walk", true);
            Carlito_anim.SetBool("shoot", true);


        }
        else if (Input.GetKey(KeyCode.Q) || left)
        {
            transform.Translate(new Vector3(0, 0, -speed ));
            ori.eulerAngles += new Vector3(0, 180, 0);
            Carlito_anim.SetBool("walk", true);
            Carlito_anim.SetBool("shoot", true);


        }
        else
        {
            Carlito_anim.SetBool("walk", false);
            Carlito_anim.SetBool("shoot", false);

            //Carlito_anim.Play("empty");
        }



        //if (Input.GetKey(KeyCode.S))
        //{
        //    //transform.Translate(new Vector3(0.2F, 0, 0));
        //    ori.eulerAngles += new Vector3(0, 90, 0);

        //}

        //if (Input.GetKey(KeyCode.Q))
        //{
        //    //transform.Translate(new Vector3(0, 0, -0.2F));
        //    ori.eulerAngles += new Vector3(0, 180, 0);

        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    //transform.Translate(new Vector3(0, 0, 0.2F));
        //    ori.eulerAngles += new Vector3(0, 0, 0);
        //}

        Carlito.transform.localRotation= ori;
    }

    
}
