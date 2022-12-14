using System.Collections;
using System.Collections.Generic;
using ScriptableReferences.Float;
using ScriptableReferences.Vectors;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    [SerializeField] private FloatReference horizontalSensitivity;


    private Transform m_transform;
    private float m_mouseX;

    private void Awake()
    {
        m_transform = transform;
    }//Closes Awake method


    private void Update()
    {
        m_mouseX = Input.GetAxis("Mouse X") * horizontalSensitivity.value * Time.deltaTime;
        m_transform.Rotate(Vector3.up * m_mouseX);
    }//Closes LateUpdate method

}//Closes MouseRotation class
