using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    
    // Start is called before the first frame update
    private int destPoint = 0;
    private float randSpeed = 1;
    private NavMeshAgent agent;
    private Animator animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RandomWalkingAround();
    }

    void RandomWalkingAround()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f) { StartCoroutine("GoNextPoint"); }
        animator.SetTrigger("Walking1Trigger");
        animator.ResetTrigger("IdleTrigger");
        //TODO: Walking animation
    }

    IEnumerator GoNextPoint()
    {
        destPoint = Random.Range(0, DestinationPointsController.destPoints.Length);
        randSpeed = Random.Range(1,4);
        agent.destination = DestinationPointsController.destPoints[destPoint].position;
        agent.speed = randSpeed;
        yield return null;
    }
}
