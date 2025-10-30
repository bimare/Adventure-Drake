using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
	public HealthBar healthBar;
	public int maxHealth = 200;
	public int currentHealth;
	public Animator anim;

	public bool isInvulnerable = false;

	void Start()
	{
		currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
	}

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
		 anim.SetTrigger("BosLuka");

		if (currentHealth > 100)
		{
			anim.SetTrigger("BosLuka");
		}

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		healthBar.SetHealth(currentHealth);
		 anim.SetTrigger("BosMati");	
		Destroy(gameObject, 3);
	}

}
