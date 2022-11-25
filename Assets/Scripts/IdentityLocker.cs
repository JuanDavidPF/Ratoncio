using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdentityLocker : MonoBehaviour
{
    public bool IsActive;
    private Quaternion identity;
    private Transform m_transform;
    private void Awake()
    {
        m_transform = transform;
        identity = Quaternion.identity;
    }//Closes Awake method
    private void Update()
    {
        if (IsActive) m_transform.rotation = identity;

    }//Closes Update method
}//Closes RotationLocker method
