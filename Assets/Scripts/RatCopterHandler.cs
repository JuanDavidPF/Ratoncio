using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ratoncio
{

    public class RatCopterHandler : MonoBehaviour
    {
        private Transform m_t;
        private float rotationSpeed = 100;

        private void Awake()
        {
            m_t = transform;
        }//Closes Awake method

        private void Update()
        {
            m_t.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
        }//Closes Update method

    }//Closes RatCopterHandler
}//Closes Namespace declaration

