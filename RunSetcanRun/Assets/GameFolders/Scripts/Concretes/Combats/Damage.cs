using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunSetcanRun.Combats
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] int damage;

        public int HitDamage => damage;

        public void HitTarger(Health health)
        {
            health.TakeHit(this);
        }
    }
}
