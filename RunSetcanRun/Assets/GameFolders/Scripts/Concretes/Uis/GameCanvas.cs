using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunSetcanRun.Uis
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] GameObject gamePlayObject;
        [SerializeField] GameOverPanel gameOverPanel;
        [SerializeField] GameFinishPanel gameFinishPanel;

        private void OnEnable()
        {
            GameManager.Instance.OnSceneChanged += HandleScneChanged;    
        }

        private void OnDisable()
        {
            GameManager.Instance.OnSceneChanged -= HandleScneChanged;

        }

        private void HandleScneChanged(bool isActive)
        {
            if (!isActive == gamePlayObject.activeSelf) return;
            gamePlayObject.SetActive(!isActive);
        }

        public void ShowGameOverPanel()
        {
            gameOverPanel.gameObject.SetActive(true);
        }

        public void ShowGameFinishPanel()
        {
            gameFinishPanel.gameObject.SetActive(true);
        }
    }
}
