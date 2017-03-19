using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour
{

    private GUIControlScript GUIscript;
    private Transform myTransform;
    private Vector3 destinationPosition;
    private float destinationDistance;
    private bool isObject = false;
    private Quaternion targetRotation;
    private UnityEngine.AI.NavMeshAgent agent;

    //public float multiplier = 1.0f; //default speed is x1
    //public float moveSpeed; //for display purpose only
     

	// Use this for initialization
	void Start () {
        myTransform = transform;
        destinationPosition = myTransform.position; //On startup, destination = current position
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        GUIscript = GetComponent<GUIControlScript>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);

        if (Input.GetMouseButtonDown(0) && GUIUtility.hotControl == 0 && !isObject)
        {
            Plane playerPlane = new Plane(Vector3.up, myTransform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float hitdist = 0.0f;

            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);
                destinationPosition = ray.GetPoint(hitdist);
            }
        }

        //Debug.Log(destinationDistance);

        //TODO: Add 1 second latency when switching GUIactive from True to false so it doesn't detect right away
        //Use WaitforSecond()
        if(destinationDistance > .5f && !GUIscript.GUIactive)
        {
            agent.SetDestination(destinationPosition);
        }
        
    }

}
