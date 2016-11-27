using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class HorcanController : PlatformerCharacter2D
    {
		private bool m_bigJump = false;
		private float m_timerJump = 0f;

        private void FixedUpdate()
        {
            m_Grounded = false;

			// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
			// This can be done using layers instead but Sample Assets will not overwrite your project settings.
			Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
			if (touchesWater(colliders))
				restartLevel();
			else
			{
				for (int i = 0; i < colliders.Length; i++)
				{
					if (colliders[i].gameObject != gameObject && !m_bigJump)
					{
						m_Grounded = true;
					}
				}
				m_Anim.SetBool("Ground", m_Grounded);

				// Set the vertical animation
				m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
				if (!m_Jump)
				{
					// Read the jump input in Update so button presses aren't missed.
					m_Jump = Input.GetButtonDown("JumpHorcan");
				}
			}
		}


        public override void Move()
		{
			// Read the inputs.
			float move = Input.GetAxis("HorizontalHorcan");

            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
				if (m_Grounded)
					m_timerJump = 0f;

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

				// Move the character
				if (m_bigJump)
					m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed / 4f, m_JumpForce*2*(0.3f-m_timerJump*m_timerJump));
				else if(!m_Grounded && m_timerJump > 0f)
					m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed/4f, m_Rigidbody2D.velocity.y);
				else
					m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

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

			if (Input.GetKeyDown(KeyCode.E) && m_timerJump < 0.3f)
			{
				m_Rigidbody2D.gravityScale = 0;
				m_timerJump += 0.01f;
				m_bigJump = true;
				m_Grounded = false;
				m_Anim.SetBool("Ground", false);
			}
			else if(m_bigJump && m_timerJump < 0.3f)
			{
				m_timerJump += 0.01f;
			}
			else
			{
				m_bigJump = false;
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
