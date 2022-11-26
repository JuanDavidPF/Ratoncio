using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableReferences.Bool
{
    public class BoolListener : MonoBehaviour
    {

        [TextArea(1, 5)]
        [SerializeField] private string eventDescription;

        [Space(20)]
        [SerializeField] private BoolVariable boolVariable;
        [SerializeField] private UnityEvent<bool> Response;

        protected void OnEnable()
        {
            boolVariable.Listen(this);
        }//closes OnEnable method

        protected void OnDisable()
        {
            if (!boolVariable) return;
            boolVariable.Unlisten(this);
        }//closes OnDisable method

        [ContextMenu("Raise Event")]
        public void Invoke()
        {
            if (!boolVariable) return;
            Response.Invoke(boolVariable.value);
        }//Closes Invoke method

    }//closes FloatListener Class
}//Closes Namespace declaration
