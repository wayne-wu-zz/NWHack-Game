using UnityEngine;
using System.Collections;

public class SheepBehaviour : MonoBehaviour {

    public GameObject tower;
    public float multiplier = 1.0f;

    private Vector3 tower_location;
    private Transform myTransform;
    private UnityEngine.AI.NavMeshAgent agent;

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        tower_location = tower.transform.position;
        myTransform = gameObject.transform;

	}
	
	// Update is called once per frame
	void Update ()
    {

        float destination_distance = Vector3.Distance(tower_location, myTransform.position);
	    if (destination_distance >= 2f)
        {
            //move towards the tower 
            agent.SetDestination(tower_location);
        }
        else
        {
            agent.Stop();

            //*TODO: Apply smooth rotation
            Quaternion targetRotation = Quaternion.LookRotation(tower_location - transform.position);
            myTransform.rotation = targetRotation;
        }

    }
}
