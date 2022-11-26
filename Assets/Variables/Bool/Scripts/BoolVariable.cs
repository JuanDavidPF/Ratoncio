using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ScriptableReferences.Bool
{
    [CreateAssetMenu(fileName = ("newBoolVariable"), menuName = ("Variables/Bool"))]
    public class BoolVariable : ScriptableObject
    {

        private List<BoolListener> listeners = new List<BoolListener>();

        [SerializeField] private bool _value;
        public bool value { get { return _value; } set { _value = value; OnChange(); } }


        public void OnChange()
        {
            foreach (BoolListener listener in listeners)
            {
                if (!listener) { Unlisten(listener); continue; }
                listener.Invoke();
            }
        }//closes Invoke method

        public void Listen(BoolListener listener)
        {
            if (listeners.Contains(listener)) return;
            listeners.Add(listener);
        }//closes RegisterListener method

        public void Unlisten(BoolListener listener)
        {
            listeners.Remove(listener);
        }//closes UnRegisterListener method



    }//closes FloatVariable class
}//Closes Namespace declaration