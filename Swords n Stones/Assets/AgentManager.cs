using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour
{
    List<NavMeshAgent> agents = new List<NavMeshAgent>();
    public GameObject Target;
    public float SeekArea;
    public float SeekAreaMax;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] a = GameObject.FindGameObjectsWithTag("AI");
        foreach(GameObject go in a)
        {
            agents.Add(go.GetComponent<NavMeshAgent>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(NavMeshAgent a in agents)
        {   
            float d = distance(a,Target);
            if(d< SeekArea)
            {
                a.SetDestination(Target.transform.position);
            }
            else if (d > SeekAreaMax)
            {
                a.SetDestination(a.transform.position);
            }
            
        }
    }

    float distance(NavMeshAgent a, GameObject b)
    {
        return (Vector3.SqrMagnitude(a.transform.position - b.transform.position));
    }
}
