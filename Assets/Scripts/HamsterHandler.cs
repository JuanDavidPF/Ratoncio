using System.Collections;
using System.Collections.Generic;
using ScriptableReferences.Bool;
using ScriptableReferences.Vectors;
using UnityEngine;

namespace Ratoncio
{
    [RequireComponent(typeof(Animator))]
    public class HamsterHandler : MonoBehaviour
    {
        [SerializeField] private BoolReference isGrounded;
        [SerializeField] private Vector3Reference ballVelocity;

        private Transform m_transform;
        private Animator m_animator;

        private void Awake()
        {
            m_transform = transform;
            m_animator = GetComponent<Animator>();

        }//Closes Awake method;

        private void LateUpdate()
        {
            HandleHamsterDirection();
            HandleHamsterAnimations();
        }//Closes LateUpdate method
        public void HandleHamsterDirection()
        {
            Vector3 direction = ballVelocity.value;
            direction.y *= 0.1f;
            m_transform.rotation = Quaternion.LookRotation(direction);
        }//Closes HandleHamsterDirection method


        public void HandleHamsterAnimations()
        {
            float speed = new Vector3(ballVelocity.value.x, 0, ballVelocity.value.z).magnitude / 2f;

            m_animator.SetBool("isGrounded", isGrounded.value);
            m_animator.SetFloat("speed", speed);
            m_animator.speed = Mathf.Max(speed, 1);
        }//Closes HandleHamsterAnimations method


    }//Closes HamsterHandler class
}//Closes Namespace declaration