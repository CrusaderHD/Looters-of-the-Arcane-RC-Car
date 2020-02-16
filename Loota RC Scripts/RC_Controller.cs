using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_Controller : MonoBehaviour {

    public enum PlayerInput{ WASD, arrowKeys };
    public PlayerInput pInput = PlayerInput.WASD;
    public RC_Motor rcMotor;
    public RC_Data rcData;

	//public List gameList[];


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        playerMovement();
	}

    //This function will use a switch/case so player movement can be changed in the inspector and give the player different options.
    public void playerMovement()
    {
        switch (pInput)
        {
            case PlayerInput.WASD:
                rcMotor.moveCar(Input.GetAxis("Vertical"));
                rcMotor.turnWheels(Input.GetAxis("Horizontal"));
                rcMotor.spinWheels(Input.GetAxis("Vertical"));
                break;

            case PlayerInput.arrowKeys:
                rcMotor.moveCar(Input.GetAxis("P2Vertical"));
                //rcMotor.rotateCar(Input.GetAxis("P2Horizontal"));
                break;
        }
    }

//	public void UpdateCamera()
//	{
//		Adjusts camera with the camera anchor, applies the camera offset to stabilizes the camera
//		cameraAnchor.rotation = Quaternion.Euler(cameraAnchor.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
//		myCamera.transform.position = cameraPoint.position + cameraOffset;
//		myCamera.transform.rotation = cameraAnchor.rotation;
//	}
}
