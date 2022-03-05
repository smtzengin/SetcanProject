using RunSetcanRun.Combats;
using RunSetcanRun.Controllers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RunSetcanRun.Managers
{
    public class CheckpointManager : MonoBehaviour
    {
        [SerializeField] CheckpointController[] _checkpointControllers;

        Health _health;

        private void Awake()
        {
            _checkpointControllers = GetComponentsInChildren<CheckpointController>();
            _health = FindObjectOfType<PlayerController>().GetComponent<Health>();
        }

        private void Start()
        {
            _health.OnHealthChanged += HandleHealthChanged;
        }

        private void HandleHealthChanged(int currentHealth, int maxHealth)
        {
            _health.transform.position = _checkpointControllers.LastOrDefault(x => x.IsPassed).transform.position;
        }
    }
}
