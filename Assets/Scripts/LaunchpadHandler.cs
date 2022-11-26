using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ratoncio
{
    [RequireComponent(typeof(Rigidbody))]
    public class LaunchpadHandler : MonoBehaviour
    {
        [SerializeField] private float launchpadForce;
        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.TryGetComponent(out Rigidbody rb))
            {
                rb.AddForce(Vector3.up * launchpadForce, ForceMode.VelocityChange);
            }
        }//Closes OnCollisionEnter method
    }//Closes LaunchpadHandler class
}//Closes Namespace declaration
