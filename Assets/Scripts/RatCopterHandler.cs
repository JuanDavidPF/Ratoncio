using System.Collections;
using System.Collections.Generic;
using ScriptableReferences.Bool;
using ScriptableReferences.Float;
using UnityEngine;

namespace Ratoncio
{
    [RequireComponent(typeof(Animator))]
    public class RatCopterHandler : MonoBehaviour
    {
        [SerializeField] private BoolReference isGrounded;

        [Space(10)]
        [Header("Boost Variables")]
        [SerializeField] private BoolReference isBoosting;


        [Space(10)]
        [Header("Fuel Variables")]
        [SerializeField] private FloatReference fuelCapacity;
        [SerializeField] private FloatReference fuel;
        [SerializeField] private FloatReference refilllRate;


        private Transform m_t;
        private Animator m_animator;
        private void Awake()
        {
            m_t = transform;
            m_animator = GetComponent<Animator>();
        }//Closes Awake method

        private void Update()
        {
            if (isGrounded.value || fuel.value == 0 || Input.GetKeyUp(KeyCode.Space))
            {
                isBoosting.value = false;
                m_animator.SetBool("isSpinning", false);
            }


            if (isGrounded.value)
            {
                fuel.value += refilllRate.value * Time.deltaTime;
                if (fuel.value > fuelCapacity.value) fuel.value = fuelCapacity.value;
            }

            if (fuel.value > 0 && Input.GetKeyDown(KeyCode.Space))
            {
                isBoosting.value = true;
                m_animator.SetBool("isSpinning", true);
            }

            if (isBoosting.value)
            {
                fuel.value -= Time.deltaTime;
                if (fuel.value < 0) fuel.value = 0;
            }



        }//Closes Update method

    }//Closes RatCopterHandler
}//Closes Namespace declaration

