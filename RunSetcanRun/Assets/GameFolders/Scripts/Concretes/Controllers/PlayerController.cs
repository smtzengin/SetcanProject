using RunSetcanRun.Abstracts.Inputs;
using RunSetcanRun.Animations;
using RunSetcanRun.Combats;
using RunSetcanRun.Inputs;
using RunSetcanRun.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunSetcanRun.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        CharacterAnimation _characterAnimation;
        bool _isJump;
        float _horizontal;
        float _vertical;

        IPlayerInput _input;
        Mover _mover;
        Flip _flip;
        Jump _jump;
        OnGround _onGround;
        Health _health;
        Damage _damage;

        public void Awake()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _mover = GetComponent<Mover>();
            _flip = GetComponent<Flip>();
            _jump = GetComponent<Jump>();
            _onGround = GetComponent<OnGround>();
            _health = GetComponent<Health>();
            _damage = GetComponent<Damage>();
            _input = new PcInput();
 
        }



        public void Update()
        {
            _horizontal = _input.Horizontal;
            _vertical = _input.Vertical;
            if (_input.isJumpButtonDown && _onGround.IsOnGround)
            {
                _jump.JumpAction();
                _isJump = true;
            }

            _characterAnimation.MoveAnimation(_horizontal);
            _characterAnimation.JumpAnimation(!_onGround.IsOnGround && _jump.IsJump);


        }

        public void FixedUpdate()
        {
            _mover.HorizontalMove(_horizontal);
            _flip.FlipCharacter(_horizontal);

            if (_isJump)
            {
                _jump.JumpAction();
                _isJump = false;
            }
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "tag_final_collider")
            {
                GameManager.Instance.LoadScene(1);
            }
        }


    }
}
