using UnityEngine;
using System.Collections;

public class MouseClickTest : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Cursor.visible = true;
	}

    float screen_w = Screen.width;
    float screen_h = Screen.height;

    // Update is called once per frame
    void Update ()
    {
        var camera = Camera.main;
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 center = new Vector3(screen_w/2, screen_h/2, 0);
            Debug.Log(center);
            Vector3 mouse_position = ((-center + Input.mousePosition)/100);
            mouse_position.z = mouse_position.y;
            mouse_position.y = 0.0f;
            Debug.Log(mouse_position);
            gameObject.transform.position = mouse_position;

        }
	}
}
