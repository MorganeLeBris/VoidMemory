using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
        }


        private void FixedUpdate()
        {
            // Pass all parameters to the character control script.
            m_Character.Move();
        }

		void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Pick Up"))
			{
				other.gameObject.SetActive(false);
			}
		}
	}
}
