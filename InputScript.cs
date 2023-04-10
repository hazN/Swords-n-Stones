using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 0.5f;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //so it looks at how many clicks have been made and if one animation has finished playing starts another one.
            lastClickedTime = Time.time;
            noOfClicks++;
            if (noOfClicks == 1)
            {
                anim.SetBool("hit1", true);
            }

            noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

            if (noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 1.1f &&
                anim.GetCurrentAnimatorStateInfo(1).IsName("hit1"))
            {
                anim.SetBool("hit1", false);
                anim.SetBool("hit2", true);
            }

            if (noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 1.1f &&
                anim.GetCurrentAnimatorStateInfo(1).IsName("hit2"))
            {
                anim.SetBool("hit2", false);
                anim.SetBool("hit3", true);
            }
        }

        if (anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 1.1f && anim.GetCurrentAnimatorStateInfo(1).IsName("hit1"))
        {
            anim.SetBool("hit1", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 1.1f && anim.GetCurrentAnimatorStateInfo(1).IsName("hit2"))
        {
            anim.SetBool("hit2", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 1.1f && anim.GetCurrentAnimatorStateInfo(1).IsName("hit3"))
        {
            anim.SetBool("hit3", false);
            noOfClicks = 0;
        }


        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }
    }
}
