using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableReferences.Vectors
{
    [Serializable]
    public class Vector3Reference
    {
        public bool useConstant = true;
        public Vector3 constantValue;
        public Vector3Variable variable;
        private List<Vector3Listener> listeners = new List<Vector3Listener>();

        public Vector3 value
        {
            get { return useConstant ? constantValue : variable.value; }
            set
            {
                if (useConstant)
                {
                    constantValue = value;
                    OnChange();
                }
                else if (variable) variable.value = value;

            }
        }

        public void OnChange()
        {
            if (!useConstant) return;

            foreach (Vector3Listener listener in listeners)
            {
                if (!listener) { Unlisten(listener); continue; }
                listener.Invoke();
            }

        }//closes OnChange method

        public void Listen(Vector3Listener listener)
        {
            variable.Listen(listener);
            if (!listeners.Contains(listener)) listeners.Add(listener);

        }//closes Listen method

        public void Unlisten(Vector3Listener listener)
        {
            variable.Unlisten(listener);
            listeners.Remove(listener);
        }//closes Unlisten method

    }//closes FloatReference class
}//Closes Namespace declaration