using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AI : MonoBehaviour
{
    public GameObject Goal;
    Vector3 direction;
    float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //Dir = Goal.transform.position - this.transform.position;
        //Dir = dir.normalized;

    }

    // Update is called once per frame
    private void LateUpdate()
    {
        direction = Goal.transform.position - this.transform.position;
        this.transform.LookAt(Goal.transform.position);
        if(direction.magnitude > 2)
        {
            Vector3 velocity = direction.normalized * speed * Time.deltaTime;
            this.transform.position = this.transform.position + velocity;
        }
    }
}
