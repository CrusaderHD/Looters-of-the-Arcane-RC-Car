using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_Camera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.LookAt (gameObject.transform.parent);
	}
}
