using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour {

	public string text;
	public bool display = false;

	public Camera rcCarCamera;
	public Camera playerModelCamera;

	public RC_Controller rcController;
	public PMC playerController;


	// Use this for initialization
	void Start () {

		rcCarCamera.enabled = false;
		playerModelCamera.enabled = true;
		rcController.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		

		if (display == true)
		{
			if (Input.GetKeyDown (KeyCode.C)) 
			{
				playerModelCamera.enabled = false;
				rcCarCamera.enabled = true;
				rcController.enabled = true;
				playerController.enabled = false;

			}
			else if(Input.GetKeyDown(KeyCode.R))
			{
				playerModelCamera.enabled = true;
				rcCarCamera.enabled = false;
				rcController.enabled = false;
				playerController.enabled = true;
			}
		}
	}

	void OnTriggerEnter(Collider pCollider)
	{
		if (pCollider.transform.name == "PlayerModel") 
		{
			display = true;
		}
	}

	void OnTriggerExit(Collider eCollider)
	{
		if (eCollider.transform.name == "PlayerModel") 
		{
			display = false;
		}
	}

	void OnGUI()
	{
		if (display == true) 
		{
			GUI.Box (new Rect (825, 375, 350, 40), text);
		}
	}
}
