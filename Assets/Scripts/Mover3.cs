using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover3 : MonoBehaviour
{

    Rigidbody PlayerBody;
    GameObject StatsManager;
    public float maxSpeed;



    // Use this for initialization
    void Start()
    {
        PlayerBody = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (PlayerBody.velocity.magnitude < maxSpeed)
                PlayerBody.AddForce(2F, 0F, 0F);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            if (PlayerBody.velocity.magnitude < maxSpeed)
                PlayerBody.AddForce(-2F, 0F, 0F);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            if (PlayerBody.velocity.magnitude < maxSpeed)
                PlayerBody.AddForce(0F, 0F, 2F);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (PlayerBody.velocity.magnitude < maxSpeed)
                PlayerBody.AddForce(0F, 0F, -2F);
        }
        // Debug.Log(PlayerBody.velocity.magnitude);
    }

}
