using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public int maxHealth;
   public int currentHealth;
   
   public Animator anim;
   public PlayerHealth PlayerHP;

   //bool dead = false;
   //bool hit = false;

   //private float dazedTime;
   //public float startDazedTime;
   //EnemyMovement e;

   [SerializeField] private AudioClip SoundDead;
   [SerializeField] private AudioClip SoundHurt;

   void Start()
   {
    currentHealth = maxHealth; 
   }

   void Update()
   {
    
   }

   public void TakeDamage(int damage)
   {
    SoundManager.instance.PlaySound(SoundHurt);
    currentHealth -= damage;
    anim.SetTrigger("MusuhLuka");
    
    if (currentHealth <=0)
    { 
        Die();
    }

   }

   public void Die()
   {
    Debug.Log("Enemy Die");
    Destroy(gameObject, 2);
    anim.SetBool("IsMati",true);
    SoundManager.instance.PlaySound(SoundDead);
    GetComponent<Collider2D>().enabled = false;
    this.enabled = false;

   }

}
