using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableReferences.Bool
{
    [Serializable]
    public class BoolReference
    {
        public bool useConstant = true;
        public bool constantValue;
        public BoolVariable variable;
        private List<BoolListener> listeners = new List<BoolListener>();

        public bool value
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

            foreach (BoolListener listener in listeners)
            {
                if (!listener) { Unlisten(listener); continue; }
                listener.Invoke();
            }

        }//closes OnChange method

        public void Listen(BoolListener listener)
        {
            variable.Listen(listener);
            if (!listeners.Contains(listener)) listeners.Add(listener);

        }//closes Listen method

        public void Unlisten(BoolListener listener)
        {
            variable.Unlisten(listener);
            listeners.Remove(listener);
        }//closes Unlisten method

    }//closes FloatReference class
}//Closes Namespace declaration