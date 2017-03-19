using System;
using UnityEngine;

namespace SheepAsset
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof(SheepControl))]
    public class SheepAIControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
        public SheepControl character { get; private set; } // the character we are controlling
        public Transform target; // target to aim for

        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<SheepControl>();

            agent.updateRotation = false;
            agent.updatePosition = true;
        }


        // Update is called once per frame
        private void Update()
        {
            float destination_distance = Vector3.Distance(target.position, character.transform.position);
            if (target != null && destination_distance >= 2.0f)
            {
                agent.SetDestination(target.position);

                // use the values to move the character
                character.Move(agent.desiredVelocity, false, false);
            }
            else
            {
                // We still need to call the character's move function, but we send zeroed input as the move param.
                character.Move(Vector3.zero, false, false);
                agent.Stop(); //Might not need this for now
            }

        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
