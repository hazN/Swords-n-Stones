using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZombie : MonoBehaviour
{
    public AttackScript attackScript;
    // Start is called before the first frame update
    void Start()
    {
        attackScript = GetComponentInParent<AttackScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

}
