using RunSetcanRun.Uis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunSetcanRun.Combats
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int maxHealth = 3;
        [SerializeField] int currentHealth = 0;

        public bool IsDead => currentHealth < 1;

        public event System.Action<int,int> OnHealthChanged;
        public event System.Action OnDead;

        DisplayScore _displayScore;


        private void Awake()
        {
            currentHealth = maxHealth;
            _displayScore = FindObjectOfType<DisplayScore>();

        }
        private void Start()
        {
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }
        public void TakeHit(Damage damage)
        {
            if (IsDead) return;

            currentHealth -= damage.HitDamage;

            if (IsDead)
            {
                OnDead?.Invoke();
                GameManager.Instance.score = 0;
                _displayScore.HandleScoreChanged(0);
            }
            else
            {
                OnHealthChanged?.Invoke(currentHealth, maxHealth);
            }
        }
    }
}
