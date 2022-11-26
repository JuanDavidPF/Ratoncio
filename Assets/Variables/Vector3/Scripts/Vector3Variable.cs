using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ScriptableReferences.Vectors
{
    [CreateAssetMenu(fileName = ("newVector3Variable"), menuName = ("Variables/Vector3"))]
    public class Vector3Variable : ScriptableObject
    {

        private List<Vector3Listener> listeners = new List<Vector3Listener>();

        [SerializeField] private Vector3 _value;
        public Vector3 value { get { return _value; } set { _value = value; OnChange(); } }


        public void OnChange()
        {
            foreach (Vector3Listener listener in listeners)
            {
                if (!listener) { Unlisten(listener); continue; }
                listener.Invoke();
            }
        }//closes Invoke method

        public void Listen(Vector3Listener listener)
        {
            if (listeners.Contains(listener)) return;
            listeners.Add(listener);
        }//closes RegisterListener method

        public void Unlisten(Vector3Listener listener)
        {
            listeners.Remove(listener);
        }//closes UnRegisterListener method

    }//closes FloatVariable class
}//Closes Namespace declaration