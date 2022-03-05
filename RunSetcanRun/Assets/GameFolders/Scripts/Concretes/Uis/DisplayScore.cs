using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RunSetcanRun.Uis
{

    public class DisplayScore : MonoBehaviour
    {
        TextMeshProUGUI _scoreText;

        public TextMeshProUGUI ScoreText => _scoreText;

        private void Awake()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            GameManager.Instance.OnScoreChanged += HandleScoreChanged;
        }
        private void OnDisable()
        {
            GameManager.Instance.OnScoreChanged += HandleScoreChanged;
        }
        public void HandleScoreChanged(int score)
        {
            _scoreText.text = score.ToString();    
        }

        
    }

}
