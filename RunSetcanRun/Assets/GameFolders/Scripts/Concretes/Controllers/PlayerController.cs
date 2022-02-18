using RunSetcanRun.Abstracts.Inputs;
using RunSetcanRun.Animations;
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

        public void Awake()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _mover = GetComponent<Mover>();
            _flip = GetComponent<Flip>();
            _jump = GetComponent<Jump>();
            _input = new PcInput();

        }

        public void Update()
        {
            _horizontal = _input.Horizontal;
            _vertical = _input.Vertical;
            if (_input.isJumpButtonDown)
            {
                _jump.JumpAction();
                _isJump = true;
            }

            _characterAnimation.MoveAnimation(_horizontal);
            _characterAnimation.JumpAnimation(_jump.IsJump);
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
    }
}
