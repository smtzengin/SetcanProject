using RunSetcanRun.Combats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunSetcanRun.Controllers
{
    public class DeadZoneController : MonoBehaviour
    {
        Damage _damage;
        private void Awake()
        {
            _damage = GetComponent<Damage>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health health = collision.collider.GetComponent<Health>();

            if (health != null)
            {
                health.TakeHit(_damage);
            }
        }
    }
}
