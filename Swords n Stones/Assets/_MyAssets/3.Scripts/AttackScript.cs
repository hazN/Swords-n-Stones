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
    public readonly int m_HashAttack1 = Animator.StringToHash("Attack1");
    public readonly int m_HashAttack2 = Animator.StringToHash("Attack2");
    public readonly int m_HashAttack3 = Animator.StringToHash("Attack3");
    public InputAction attack;
    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
        attack = _input.actions["attack"];
    }

    // Update is called once per frame
    void Update()
    {
        if(attack.triggered)
        {
            lastClickedTime = Time.time;
            noOfClicks++;
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
            }
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
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
        }
    }
}
