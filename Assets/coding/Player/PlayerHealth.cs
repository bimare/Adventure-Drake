using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    

    public int maxHealth;
    public int currentHealth;
    public Animator anim;
    bool dead = false;
    public HealthBar healthBar;
    private bool invulnerable;

    [SerializeField] private AudioClip SoundDead;
    [SerializeField] private AudioClip HurtDead;
    [SerializeField] private Behaviour[] components;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
   
    // Start is called before the first frame update
    void Start()
    {
       
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (invulnerable) return;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        anim.SetTrigger("IniLuka");
        SoundManager.instance.PlaySound(HurtDead);
         if (currentHealth <=0)
        { 
            dead = true;
            Debug.Log("Kalah");
            if(dead == true)
            {
                foreach (Behaviour component in components)
                    component.enabled = false;
                SoundManager.instance.PlaySound(SoundDead);
                anim.SetTrigger("IniMati");
                //Destroy(gameObject, 2);
            }
        }
    }

    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(8, 8, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
           
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(8, 8, false);
        invulnerable = false;
    }

    void Dead()
    {
        //sceen game over
    }

   /* private void OnCollisionEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Trap")
        {
            TakeDamage(100);
        }
    }*/

    

    public void Healing (int healhp)
    {
        currentHealth += healhp;
        healthBar.SetHealth(currentHealth);

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    }

    public void Respawn()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        anim.ResetTrigger("IniMati");
        anim.Play("drake_idle");
        dead = false;
        StartCoroutine(Invunerability());

        //Activate all attached component classes
        foreach (Behaviour component in components)
            component.enabled = true;
    }

}
