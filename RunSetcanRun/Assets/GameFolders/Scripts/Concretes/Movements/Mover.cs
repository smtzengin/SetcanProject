using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunSetcanRun.Movements
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float speed = 7f;

        public void HorizontalMove(float horizontal)
        {
            transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);
        }
    }
}
