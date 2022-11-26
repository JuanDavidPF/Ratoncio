using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ratoncio
{
    public class Door : MonoBehaviour
    {

        private void OnCollisionEnter(Collision other)
        {

            if (other.transform.TryGetComponent(out Key key))
            {
                Destroy(key.gameObject);
                Destroy(gameObject);
            }
        }//Closes OnColissionEnter method
    }//Closes Door class
}//Closes Namespace declaration
