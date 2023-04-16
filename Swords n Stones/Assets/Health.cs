using JetBrains.Annotations;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    Animator animator;
    public Slider healthBar;
    public bool isDead = false;
    public bool isIgnored = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        animator.SetBool("Dead", false);
    }
    public void TakeDamage(int damage)
    {
        if(gameObject.tag.CompareTo("AI") == 0)
            Debug.Log("Taking " + damage + " amount of damage");
        currentHealth -= damage;
        if (healthBar)
        {
            healthBar.value = currentHealth;
        }
        if (currentHealth <= 0)
        {
            isDead = true;
            if (gameObject.CompareTag("AI"))
            {
                KillCounter killCounter = GameObject.Find("ZombieManager").GetComponent<KillCounter>();
                killCounter.UpdateZombiesKilled();
            }
            GetComponent<BoxCollider>().enabled = false;
            var thirdPersonController = GetComponent<ThirdPersonController>();
            if(thirdPersonController!= null)
            {
                thirdPersonController.enabled = false;
            }
            var attackScript = GetComponent<AttackScript>();
            if(attackScript != null)
            {
                attackScript.enabled = false;
            }
            animator.SetBool("Dead", true);
        }
    }
}
