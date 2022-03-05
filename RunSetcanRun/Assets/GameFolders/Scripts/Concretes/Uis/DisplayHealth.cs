using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RunSetcanRun.Uis
{
    public class DisplayHealth : MonoBehaviour
    {
        TextMeshProUGUI _healthText;

        private void Awake()
        {
            _healthText = GetComponent<TextMeshProUGUI>();
        }

        public void WriteHealth(int currentHealth,int maxHealth)
        {
            _healthText.text = currentHealth.ToString();
        }
    }

}
