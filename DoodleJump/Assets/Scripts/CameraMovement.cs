using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform m_ObjectToFollow;    // The object to follow.

    // **************************************************
    // Update
    // **************************************************

    private void LateUpdate()
    {
        // If the player's y position is higher than the camera's move the camera up.
        if (m_ObjectToFollow.position.y > transform.position.y)
        {
            transform.position = new Vector3(0, m_ObjectToFollow.position.y, -10);
        }
    }
}
