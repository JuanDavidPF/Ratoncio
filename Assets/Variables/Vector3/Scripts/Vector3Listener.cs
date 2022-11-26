using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableReferences.Vectors
{
    public class Vector3Listener : MonoBehaviour
    {

        [TextArea(1, 5)]
        [SerializeField] private string eventDescription;

        [Space(20)]
        [SerializeField] private Vector3Variable vector3Variable;
        [SerializeField] private UnityEvent<Vector3> Response;

        protected void OnEnable()
        {
            vector3Variable.Listen(this);
        }//closes OnEnable method

        protected void OnDisable()
        {
            if (!vector3Variable) return;
            vector3Variable.Unlisten(this);
        }//closes OnDisable method

        [ContextMenu("Raise Event")]
        public void Invoke()
        {
            if (!vector3Variable) return;
            Response.Invoke(vector3Variable.value);
        }//Closes Invoke method

    }//closes FloatListener Class
}//Closes Namespace declaration
