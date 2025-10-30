using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    float nextAttack = 0f;
    public int damage;

    [SerializeField] private AudioClip attackMelle;

    void Update()
    {
        if(Time.time >= nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Attack();
                nextAttack = Time.time + 1f /attackRate;
            }

        }
        
    }


    public void Attack ()
    {
        SoundManager.instance.PlaySound(attackMelle);
        anim.SetTrigger("IniSerang");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

       foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
            //enemy.GetComponent<Boss_Health>().TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            return;
            
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
