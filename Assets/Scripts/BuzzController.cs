using UnityEngine;

namespace UnityStandardAssets._2D
{
	public class BuzzController : PlatformerCharacter2D
	{
		private float m_timerJetpack = 0f;
		private bool m_jetpackActive = false;
		
		private void FixedUpdate()
		{
			m_Grounded = false;

			// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
			// This can be done using layers instead but Sample Assets will not overwrite your project settings.
			
			Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
			if (touchesWater(colliders))
			{
				Debug.Log("touchesWater");
				restartLevel();
			}
			else
			{
				for (int i = 0; i < colliders.Length; i++)
				{
					if (colliders[i].gameObject != gameObject && !m_jetpackActive)
						m_Grounded = true;
				}
				m_Anim.SetBool("Ground", m_Grounded);

				// Set the vertical animation
				m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
				if (!m_Jump)
				{
					// Read the jump input in Update so button presses aren't missed.
					m_Jump = Input.GetButtonDown("JumpBuzz");
				}
			}
		}


		public override void Move()
		{
			// Read the inputs.
			bool crouch = Input.GetKey(KeyCode.DownArrow);
			float move = Input.GetAxis("HorizontalBuzz");
			// If crouching, check to see if the character can stand up
			if (!crouch && m_Anim.GetBool("Crouch"))
			{
				// If the character has a ceiling preventing them from standing up, keep them crouching
				if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
				{
					crouch = true;
				}
			}

			// Set whether or not the character is crouching in the animator
			m_Anim.SetBool("Crouch", crouch);

			//only control the player if grounded or airControl is turned on
			if (m_Grounded || m_AirControl)
			{
				if (m_Grounded)
				{
					m_timerJetpack = 0f;
				}
				// Reduce the speed if crouching by the crouchSpeed multiplier
				move = (crouch ? move * m_CrouchSpeed : move);

				// The Speed animator parameter is set to the absolute value of the horizontal input.
				m_Anim.SetFloat("Speed", Mathf.Abs(move));

				// Move the character
				if (Input.GetKey(KeyCode.J) && m_jetpackActive)
					m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, 0f);
				else
					m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);

				// If the input is moving the player right and the player is facing left...
				if (move > 0 && !m_FacingRight)
				{
					// ... flip the player.
					Flip();
				}
				// Otherwise if the input is moving the player left and the player is facing right...
				else if (move < 0 && m_FacingRight)
				{
					// ... flip the player.
					Flip();
				}
			}
			if (Input.GetKey(KeyCode.J) && m_timerJetpack < 1f)
			{
				m_Rigidbody2D.gravityScale = 0;
				m_timerJetpack += 0.01f;
				m_jetpackActive = true;
				m_Grounded = false;
				m_Anim.SetBool("Ground", false);
			}
			else
			{
				m_jetpackActive = false;
				m_Rigidbody2D.gravityScale = 3;
			}
			// If the player should jump...
			if (m_Grounded && m_Jump && m_Anim.GetBool("Ground"))
			{
				// Add a vertical force to the player.
				m_Grounded = false;
				m_Anim.SetBool("Ground", false);
				m_Rigidbody2D.velocity = new Vector2(0f, m_JumpForce);
			}
			m_Jump = false;
		}
	}
}
