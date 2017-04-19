using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover1 : MonoBehaviour {

    Animator Carlito_anim;
    public GameObject Carlito;
    float speed = 1;
	// Use this for initialization
	void Start () {
        Carlito_anim = Carlito.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Carlito_anim.speed = 1.3F;
        Carlito_anim.Play("walk_1");
        transform.Translate(0, 0, 0.18F);
        if (Input.GetKey(KeyCode.Z))
        {
            Carlito_anim.speed = 1.3F;
            Carlito_anim.Play("walk_1");
            transform.Translate(0, 0, 0.1F);
        }
        if (!Input.GetKey(KeyCode.Z))
        {
          //  Carlito_anim.Play("empty");
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Carlito_anim.speed = -1.3F;
            Carlito_anim.Play("walk_1");
            transform.Translate(0, 0, -0.1F);
        }
        if (!Input.GetKey(KeyCode.S))
        {
            //Carlito_anim.Play("empty");
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -1f, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1f, 0);
        }
    }
}
