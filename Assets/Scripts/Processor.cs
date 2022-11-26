using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Utilities
{
    public class Processor : MonoBehaviour
    {
        [SerializeField] private MonoBehaviourEvents events;
        [SerializeField] private UnityEvent processes;


        private void Awake()
        {
            if (events.HasFlag(MonoBehaviourEvents.Awake)) processes?.Invoke();
        }
        private void OnEnable()
        {
            if (events.HasFlag(MonoBehaviourEvents.OnEnable)) processes?.Invoke();
        }
        private void Start()
        {
            if (events.HasFlag(MonoBehaviourEvents.Start)) processes?.Invoke();
        }
        private void Update()
        {
            if (events.HasFlag(MonoBehaviourEvents.Update)) processes?.Invoke();
        }
        private void LateUpdate()
        {
            if (events.HasFlag(MonoBehaviourEvents.LateUpdate)) processes?.Invoke();
        }

        private void FixedUpdate()
        {
            if (events.HasFlag(MonoBehaviourEvents.FixedUpdate)) processes?.Invoke();
        }

        private void OnDisable()
        {
            if (events.HasFlag(MonoBehaviourEvents.OnDisable)) processes?.Invoke();
        }

        private void OnDestroy()
        {
            if (events.HasFlag(MonoBehaviourEvents.Destroy)) processes?.Invoke();
        }
    }//Closes Procesor class

    [System.Flags]
    public enum MonoBehaviourEvents
    {
        Awake = 1,
        OnEnable = 2,
        Start = 4,
        Update = 8,
        FixedUpdate = 16,
        LateUpdate = 32,
        OnDisable = 64,
        Destroy = 128

    }
}//Closes Namespace declaration
