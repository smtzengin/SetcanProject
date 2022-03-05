using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunSetcanRun.Controllers
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] int score;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player!= null)
            {
                GameManager.Instance.IncreaseScore(score);
                Destroy(this.gameObject);
            }
        }
    }
}
