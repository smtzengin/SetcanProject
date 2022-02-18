using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunSetcanRun.Movements
{ 
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jump : MonoBehaviour
    {
        [SerializeField] float jumpForce = 250f;
        Rigidbody2D _rigidbody2D;

        public bool IsJump => _rigidbody2D.velocity != Vector2.zero;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void JumpAction()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.up * jumpForce);
        }
    }
}
