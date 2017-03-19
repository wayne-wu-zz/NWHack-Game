using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start (){

	}

    public const float movementspeed = 10f;
    public const float turnspeed = 90f;

    // Update is called once per frame
    void Update () {

        Vector3 current_vec = gameObject.transform.localPosition;

        Debug.Log(current_vec);

        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * movementspeed * Time.deltaTime); 
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log("It's down");
            transform.Translate(-Vector3.back * movementspeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.localRotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * movementspeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * movementspeed * Time.deltaTime);
        }
	}
}
