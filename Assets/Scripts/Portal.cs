using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ratoncio
{
    public class Portal : MonoBehaviour
    {
        public Transform objectBeingTeleported;
        [SerializeField] private Portal destiny;

        private void OnTriggerEnter(Collider other)
        {

            Transform otherTransform = other.transform.GetComponentInParent<Rigidbody>().transform;
            if (!destiny || objectBeingTeleported == otherTransform) return;

            objectBeingTeleported = otherTransform;
            destiny.objectBeingTeleported = otherTransform;
            other.transform.position = destiny.transform.position;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform == objectBeingTeleported) objectBeingTeleported = null;
        }
    }//Closes Portal class
}//Closes Namespace declaration
