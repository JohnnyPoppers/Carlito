using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerGen : MonoBehaviour {

    public GameObject instantiator;
	// Use this for initialization
	void Start () {
        instantiator = GameObject.Find("instantiator");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collider enter : "+other.name);
       
        if(other.CompareTag("Player"))
        {
           // Debug.Log("player enter");
           if(instantiator!=null)
                instantiator.GetComponent<EnvInstantiator>().call_add(transform.position);
        }
    }
}
