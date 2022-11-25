using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMover : MonoBehaviour
{

    [Header("Misc")]
    [SerializeField] private Transform m_CameraT;


    [Space(20)]
    [Header("Ball")]
    [SerializeField] private Rigidbody m_ballRB;
    [SerializeField] float ballSpeed = 10f;
    [SerializeField] float jumpForce = 10f;


    [Space(20)]
    [Header("Hamster")]
    [SerializeField] private HamsterHandler m_hamster;


    private bool isGrounded;




    private void Awake()
    {
        if (!m_ballRB) m_ballRB = GetComponent<Rigidbody>();
        if (!m_CameraT) m_CameraT = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;


    }//Closes Awake method

    private void Start()
    {
        if (!m_hamster) m_hamster = GetComponentInChildren<HamsterHandler>();
    }//Closes Start method

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) Jump();
    }//Closes Update method

    private void FixedUpdate()
    {
        if (!isGrounded) return;
        HandleBallMovement();
    }//Closes FixedUpdate method

    private void LateUpdate()
    {
        if (!m_hamster) return;
        HandleHamsterAnimations();
        HandleHamsterDirection();

    }//Closes LateUpdate method

    private void Jump()
    {
        m_ballRB.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);

    }//Closes Jump method


    private void HandleBallMovement()
    {
        Vector3 move = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));

        float y = m_CameraT.position.y;
        move = m_CameraT.TransformDirection(move.normalized);
        m_ballRB.AddTorque(move * ballSpeed);

    }//Closes HandleBallMovement method

    private void HandleHamsterAnimations()
    {
        float speed = new Vector3(m_ballRB.velocity.x, 0, m_ballRB.velocity.z).magnitude / 2f;
        m_hamster.HandleHamsterAnimations(isGrounded, speed);

    }//Closes HandleHamsterAnimations method


    private void HandleHamsterDirection()
    {
        Vector3 direction = m_ballRB.velocity;
        direction.y *= 0.1f;
        m_hamster.HandleHamsterDirection(direction);
    }//Closes HandleHamsterDirection method



    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }//Closes OnTriggerEnter method

    private void OnTriggerExit(Collider other)
    {

        isGrounded = false;
    }//Closes OnTriggerExit method
}//Closes BallMover method
