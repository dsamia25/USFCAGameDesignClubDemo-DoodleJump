using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 1f; // The height the player jumps.
    [SerializeField] private float m_MoveSpeed = 1f; // The speed at which the player moves.
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement


    [SerializeField] private Rigidbody2D m_Rigidbody;   // The player's rigidbody. Used to move the player.

    [SerializeField] private LayerMask m_WhatIsDeadly;  // The layers that will kill the player on touch.

    private Vector3 m_Velocity = Vector3.zero;

    // **************************************************
    // Start
    // **************************************************

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // **************************************************
    // Update
    // **************************************************

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.gameIsRunning)
        {
            float movement = Input.GetAxis("Horizontal");

            // ALTERNATE MOVING METHOD
            //transform.Translate(new Vector2(movement, 0) * m_MoveSpeed * Time.deltaTime);
            // END

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(movement * 10f, m_Rigidbody.velocity.y);

            // And then smoothing it out and applying it to the character
            m_Rigidbody.velocity = Vector3.SmoothDamp(m_Rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }
    }

    // **************************************************
    // Methods
    // **************************************************

    /// <summary>
    /// Launches the player vertically using the m_JumpForce.
    /// </summary>
    private void Jump()
    {
        //Debug.Log("Jumping");
        m_Rigidbody.AddForce(m_JumpForce * Vector2.up);
    }

    // **************************************************
    // Collision
    // **************************************************

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.gameIsRunning)
        {
            Jump();

            // If the collision is in the m_IsDeadlyLayer.
            //if ()
            //{
                // GameManager.RestartLevel();
                // OR
                // OnPlayerDeathEvent.Invoke();
            //}
        }
    }
}
