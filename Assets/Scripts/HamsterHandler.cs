using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HamsterHandler : MonoBehaviour
{

    private Transform m_transform;
    private Animator m_animator;

    private void Awake()
    {
        m_transform = transform;
        m_animator = GetComponent<Animator>();

    }//Closes Awake method;
    public void HandleHamsterDirection(Vector3 direction)
    {
        m_transform.rotation = Quaternion.LookRotation(direction);
    }//Closes HandleHamsterDirection method


    public void HandleHamsterAnimations(bool isGrounded, float speed)
    {
        m_animator.SetBool("isGrounded", isGrounded);
        m_animator.SetFloat("speed", speed);
        m_animator.speed = Mathf.Max(speed, 1);
    }//Closes HandleHamsterAnimations method


}//Closes HamsterHandler class
