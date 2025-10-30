using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] public float agroRange;
    [SerializeField] public float moveSpeed;
    public Animator anim;
    Rigidbody2D rb;

    public Enemy EnemyHP;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
        //jarak player
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange)
        {
            ChasePlayer();
            anim.SetBool("MusuhLari" ,true);
        }
        else
        {
            StopChasePlayer();
             anim.SetBool("MusuhLari" ,false);
        }
    }

    void ChasePlayer()
    {
        
        if(transform.position.x < player.position.x)
        {
            rb.linearVelocity = new Vector2 (moveSpeed, 0);
            transform.localScale = new Vector2(-9,9);
            
        }
        else 
        {
            rb.linearVelocity = new Vector2 (-moveSpeed, 0);
            transform.localScale = new Vector2(9,9);
        }
    }

    void StopChasePlayer()
    {
        rb.linearVelocity = new Vector2(0,0);
    }

}