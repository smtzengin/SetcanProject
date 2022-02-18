using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunSetcanRun.Animations
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        Animator _animator;
        public void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void MoveAnimation(float horizontal)
        {
            float mathfValue = Mathf.Abs(horizontal);
            if (_animator.GetFloat("moveSpeed") == mathfValue) return;

            _animator.SetFloat("moveSpeed", mathfValue);
        }
        public void JumpAnimation(bool isJump)
        {
            if (isJump == _animator.GetBool("isJump")) return;
            _animator.SetBool("isJump", isJump);
        }
    }
}
