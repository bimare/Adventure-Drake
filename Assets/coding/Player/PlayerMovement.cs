using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;
	public Animator anim;
	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false; 
	
	[SerializeField] private AudioClip playerJump;
	// Update is called once per frame
	void Update () {

		horizontalMove = SimpleInput.GetAxisRaw("Horizontal") * runSpeed;
		anim.SetFloat("lari", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			anim.SetBool("IniLompat",true);
			SoundManager.instance.PlaySound(playerJump);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}

	//untuk mematikan animasi lompat kalau sudah menyentuh tanah
	public void OnLanding ()
	{
		anim.SetBool("IniLompat",false);
	}

	public void OnCrouching(bool isCrouching)
	{
		anim.SetBool("IniNunduk", isCrouching);
	}
	
	public void FixedUpdate ()
	{
		// untuk menggerakan karakter
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
