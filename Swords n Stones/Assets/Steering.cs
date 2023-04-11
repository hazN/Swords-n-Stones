using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Steering : MonoBehaviour
{
    //public GameObject Target;
    public NavMeshAgent agent;
    public GameObject Target;
    public float SeekArea;
    public float SeekAreaMax;
    public Health health;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        health= this.GetComponent<Health>();
    }

    void Update()
    {
        if(health.isDead) return;
        float d = distance(agent, Target);
        if (d < SeekArea)
        {
            agent.SetDestination(Target.transform.position);
        }
        else if (d > SeekAreaMax)
        {
            agent.SetDestination(agent.transform.position);
        }
    }
    float distance(NavMeshAgent a, GameObject b)
    {
        return (Vector3.SqrMagnitude(a.transform.position - b.transform.position));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //agent.SetDestination(Target.transform.position);
    }
}
