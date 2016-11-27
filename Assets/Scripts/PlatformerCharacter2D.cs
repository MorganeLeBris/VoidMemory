using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    abstract public class PlatformerCharacter2D : MonoBehaviour
    {
		[SerializeField] protected float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
		[SerializeField] protected float m_JumpForce;                  // Amount of force added when the player jumps.
		[SerializeField] protected LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character


		private float lifePoints = 3f;
		protected bool m_AirControl = true;                 // Whether or not a player can steer while jumping;
		protected Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
		protected const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
		protected bool m_Grounded;            // Whether or not the player is grounded.
		protected Transform m_CeilingCheck;   // A position marking where to check for ceilings
		protected const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
		protected Animator m_Anim;            // Reference to the player's animator component.
		protected Rigidbody2D m_Rigidbody2D;
		protected bool m_FacingRight = true;  // For determining which way the player is currently facing.
		protected bool m_Jump;
		protected bool isControlled = true;

		private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        protected void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

		abstract public void Move();

		public IEnumerator restartLevel()
		{
			int scene = SceneManager.GetActiveScene().buildIndex;
			float fadeTime = GameObject.Find("FadingBetweenScenesObject").GetComponent<Fading>().BeginFade(1);
			yield return new WaitForSeconds(fadeTime);
			SceneManager.LoadScene(scene, LoadSceneMode.Single);
		}

		public void increaseHealth()
		{
			lifePoints++;
			if (lifePoints > 3f)
				lifePoints = 3f;
		}

		public void decreaseHealth()
		{
			lifePoints--;
			if (lifePoints < 0f)
			{
				restartLevel();
				lifePoints = 3f;
			}
		}

		private void onDead()
		{
			throw new NotImplementedException();
		}

		public bool touchesWater(Collider2D[] others)
		{
			for(int i = 0; i < others.Length; i++)
			{
				if (others[i].gameObject.layer == 4)
					return true;
			}
			return false;
		}
    }
}
