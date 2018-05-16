using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

    NavMeshAgent agent;
    Transform target;

    void Update()
    {
        if(target != null)
        {
            FaceTarget();
        }
    }

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	public void MoveToPoint(Vector3 point)
    {
        agent.isStopped = false;
        agent.SetDestination(point);
    }

    public void Stop()
    {
        agent.isStopped = true;
    }

    public void FocusTarget(Interactable newTarget)
    {
        target = newTarget.interactionTranform;
    }
    public void RemoveTarget()
    {
        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
