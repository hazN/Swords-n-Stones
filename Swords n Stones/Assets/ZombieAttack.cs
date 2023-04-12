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
    private GameObject target;
    private float speed;

    private void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        animator.SetFloat("Speed", 0f);
    }

    private void Update()
    {
        speed = GetComponent<NavMeshAgent>().velocity.magnitude;
        animator.SetFloat("Speed", speed);

        if (Time.time >= nextAttackTime)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
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
        FindObjectOfType<AudioManager>().Play("ZombieAttack");
        if (health != null)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance <= range)
            {
                health.TakeDamage(dmg);
            }
        }
    }

    private void zombieDead()
    {
        FindObjectOfType<AudioManager>().Play("ZombieDead");
    }
}
