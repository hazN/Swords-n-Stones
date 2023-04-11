using UnityEngine;
using UnityEngine.AI;

public class ZombieAttack : MonoBehaviour
{
    public int dmgMin = 10;
    public int dmgMax = 20;
    public int range = 2;
    public float cooldown = 2f;
    private float nextAttackTime = 0f;
    private Animator animator;
    private Transform target;
    private float speed;

    private void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator.SetFloat("Speed", 0f);
    }

    private void Update()
    {
        speed = GetComponent<NavMeshAgent>().velocity.magnitude;
        animator.SetFloat("Speed", speed);

        if (Time.time >= nextAttackTime)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance <= range)
            {
                animator.SetTrigger("ZombieAttack");
                nextAttackTime = Time.time + cooldown;
            }
        }
    }

    public void Attack()
    {
        int dmg = Random.Range(dmgMin, dmgMax);
        var health = target.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(dmg);
        }
    }
}
