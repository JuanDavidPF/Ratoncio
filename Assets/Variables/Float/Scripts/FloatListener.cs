using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableReferences.Float
{
    public class FloatListener : MonoBehaviour
    {

        [TextArea(1, 5)]
        [SerializeField] private string eventDescription;

        [Space(20)]
        [SerializeField] private FloatVariable floatReference;
        [SerializeField] private UnityEvent<float> Response;

        protected void OnEnable()
        {
            floatReference.Listen(this);
        }//closes OnEnable method

        protected void OnDisable()
        {
            if (!floatReference) return;
            floatReference.Unlisten(this);
        }//closes OnDisable method

        [ContextMenu("Raise Event")]
        public void Invoke()
        {
            if (!floatReference) return;
            Response.Invoke(floatReference.value);
        }//Closes Invoke method

    }//closes FloatListener Class
}//Closes Namespace declaration
