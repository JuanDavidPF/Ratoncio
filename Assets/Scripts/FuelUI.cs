using System.Collections;
using System.Collections.Generic;
using ScriptableReferences.Float;
using UnityEngine;
using UnityEngine.UI;

namespace Ratoncio
{
    [RequireComponent(typeof(Image))]
    public class FuelUI : MonoBehaviour
    {
        private Image m_progressBar;

        [SerializeField] FloatReference fuelCapacity;
        [SerializeField] Gradient progressBarColor;

        private void Awake()
        {
            m_progressBar = GetComponent<Image>();
        }//Closes Awake method

        public void UpdateProgress(float value)
        {

            float normalizedValue = value / fuelCapacity.value;

            m_progressBar.fillAmount = normalizedValue;
            m_progressBar.color = progressBarColor.Evaluate(normalizedValue);
        }//Closes UpdateProgress method

    }//Closes FuelUI class
}//Closes Namespace declaration
