using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpPower;
    public LayerMask layer;
    public Transform groundCheck;
    Animator anim;
    Vector2 skalaSaatIni;
    Rigidbody2D rb;

    [SerializeField] private AudioClip playerJump;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        skalaSaatIni = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Lompat() 
    {
        //method ini berguna untuk player dapat melompat
        if (Physics2D.OverlapCircle(groundCheck.position, 0, layer))
        {
            rb.AddForce(Vector2.up * jumpPower);
            anim.SetBool("IniLompat", true);
            SoundManager.instance.PlaySound(playerJump);
        }
    }
}
