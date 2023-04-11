using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class AttackScript : MonoBehaviour
{
    public int test;
    private PlayerInput _input;
    private Animator _animator;
    public readonly int m_Attack = Animator.StringToHash("Attack");
    public readonly int m_HashAttack1 = Animator.StringToHash("Attack1");
    public readonly int m_HashAttack2 = Animator.StringToHash("Attack2");
    public readonly int m_HashAttack3 = Animator.StringToHash("Attack3");
    public InputAction attack;
    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 0.5f;
    public bool isAttacking = false;
    public ThirdPersonController controller;
    public bool isInAttackingState = false;

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
        controller = GetComponent<ThirdPersonController>();
        attack = _input.actions["attack"];
    }

    // Update is called once per frame
    void Update()
    {
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            isInAttackingState = false;
            controller.ResumeMovement();
        }
        if (attack.triggered)
        {
            isInAttackingState = true;
            isAttacking = true;
            lastClickedTime = Time.time;
            _animator.SetTrigger(m_Attack);
            controller.StopMovement();
            /* noOfClicks++;
             if (noOfClicks == 1)
             {
                 Debug.Log("Attacking..");
                 _animator.SetBool(m_HashAttack1, true);
             }

             noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
             if (noOfClicks >= 2 && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f &&
                     _animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
             {
                 Debug.Log("GetHashCode worked!!!!");
                 _animator.SetBool(m_HashAttack1, false);
                 _animator.SetBool(m_HashAttack2, true);
             }
             if (noOfClicks >= 3 && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f &&
                     _animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
             {
                 _animator.SetBool(m_HashAttack2, false);
                 _animator.SetBool(m_HashAttack3, true);
             }*/
        }
        else
        {
            if (isAttacking)
            {
                controller.canMove = true;
                isAttacking = false;
                _animator.ResetTrigger(m_Attack);
            }
        }
        /*if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            Debug.Log("Normalized time: " + _animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
            if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.15f)
                _animator.SetBool(m_HashAttack1, false);
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.1f && _animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        {
            _animator.SetBool(m_HashAttack2, false);
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.1f && _animator.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
        {
            _animator.SetBool(m_HashAttack3, false);
            noOfClicks = 0;
        }


        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }*/
    }

    public void Attack()
    {

        Collider[] zombies = Physics.OverlapSphere(gameObject.transform.position, 2.0f);
        foreach (Collider zombie in zombies)
        {
            if(zombie.tag.CompareTo("AI") == 0)
                zombie.GetComponent<Health>().TakeDamage(120);
        }
    }
}
