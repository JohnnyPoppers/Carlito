using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spherControler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 4F);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0.08F, 0, 0);
	}
}
