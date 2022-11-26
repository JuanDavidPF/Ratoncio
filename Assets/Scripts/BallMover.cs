using System.Collections;
using System.Collections.Generic;
using ScriptableReferences.Bool;
using ScriptableReferences.Float;
using ScriptableReferences.Vectors;
using UnityEngine;


namespace Ratoncio
{
    [RequireComponent(typeof(Rigidbody))]

    public class BallMover : MonoBehaviour
    {
        [Header("Variables")]
        [SerializeField] private Vector3Reference ballVelocity;
        [SerializeField] private BoolReference isGrounded;


        [Space(20)]
        [Header("Misc")]
        [SerializeField] private Transform m_CameraT;


        [Space(20)]
        [Header("Ball")]
        [SerializeField] private Rigidbody m_ballRB;
        [SerializeField] FloatReference ballSpeed;
        [SerializeField] FloatReference jumpForce;



        private void Awake()
        {
            if (!m_ballRB) m_ballRB = GetComponent<Rigidbody>();
            if (!m_CameraT) m_CameraT = Camera.main.transform;

            Cursor.lockState = CursorLockMode.Locked;


        }//Closes Awake method


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded.value) Jump();
        }//Closes Update method

        private void FixedUpdate()
        {
            HandleBallMovement();
            ballVelocity.value = m_ballRB.velocity;
        }//Closes FixedUpdate method


        private void Jump()
        {
            m_ballRB.AddForce(new Vector3(0, jumpForce.value, 0), ForceMode.Impulse);

        }//Closes Jump method

        private void HandleBallMovement()
        {
            if (!isGrounded.value || !m_CameraT) return;
            Vector3 move = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal")).normalized;
            move = m_CameraT.TransformDirection(move);

            m_ballRB.AddTorque(move * ballSpeed.value);

        }//Closes HandleBallMovement method


        private void OnTriggerEnter(Collider other)
        {
            isGrounded.value = true;
        }//Closes OnTriggerEnter method

        private void OnTriggerExit(Collider other)
        {

            isGrounded.value = false;
        }//Closes OnTriggerExit method
    }//Closes BallMover class
}//Closes namespace declaration