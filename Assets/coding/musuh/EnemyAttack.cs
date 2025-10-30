using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator anim;
    public PlayerHealth playerHP;
    public int damage;
    //public LayerMask PlayerLayers;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerHP.TakeDamage(damage);
            anim.SetTrigger("MusuhSerang");
        }
    }

    
}
