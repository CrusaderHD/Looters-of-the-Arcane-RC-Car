using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_Motor : MonoBehaviour {

    private CharacterController rcController;
    private Transform tf;
    public RC_Data rcData;

    public GameObject frontRightSteering;
    public GameObject frontLeftSteering;
    public List<GameObject> wheels = new List<GameObject>();

    public GameObject frontRightWheel;
    public GameObject frontLeftWheel;
    public GameObject rearRightWheel;
    public GameObject rearLeftWheel;


    //calling the character controller and gaining the RC Data prior to starting.
    private void Awake()
    {
        rcController = gameObject.GetComponent<CharacterController>();
        tf = gameObject.GetComponent<Transform>();

        var getRCData = GetComponent<RC_Data>();
        if (getRCData != null)
        {
            rcData = getRCData;
            Debug.Log("RC Data has been found!");
        }
        else
            Debug.Log("Error! RC Data is missing!");
    }

    // Use this for initialization
    void Start () {
        rcController = gameObject.GetComponent<CharacterController>();
	}


    //moveCar is a function that gives player access to move forward and backward. 
    //This will grab information from the RC_Data script and apply
    public void moveCar(float scale)
    {
        Vector3 move = transform.TransformDirection(Vector3.forward);
        float moveSpeed = rcData.rcSpeed * scale;
        rcController.SimpleMove(move * moveSpeed);
    }

    //Getting a 
    public void turnWheels(float scale)
    {
        float angle = scale * 30.0f;
        frontLeftSteering.transform.localEulerAngles = new Vector3(0f, angle, 0f);
		frontRightSteering.transform.localEulerAngles = new Vector3(0f, angle + 180, 0f);

		if (Input.GetKey (KeyCode.W)) {
			if (Input.GetKey (KeyCode.A)) {
				transform.Rotate (0, -rcData.rcRotate * Time.deltaTime, 0);
			}
			if (Input.GetKey (KeyCode.D)) {
				transform.Rotate (0, rcData.rcRotate * Time.deltaTime, 0);
			}
		} 
		else if (Input.GetKey (KeyCode.S)) 
		{
			if (Input.GetKey (KeyCode.A)) 
			{
				transform.Rotate (0, rcData.rcRotate * Time.deltaTime, 0);
			}
			if (Input.GetKey (KeyCode.D)) 
			{
				transform.Rotate (0, -rcData.rcRotate * Time.deltaTime, 0);
			}
		}
			
    }

    public void spinWheels(float scale)
    {
        float spin = scale * 30.0f;
        //Debug.Log("WORDS");
        frontLeftWheel.transform.Rotate(Vector3.right * spin);
        frontRightWheel.transform.Rotate(Vector3.right * spin);
        rearLeftWheel.transform.Rotate(Vector3.right * spin);
        rearRightWheel.transform.Rotate(Vector3.right * spin);
    }
}
