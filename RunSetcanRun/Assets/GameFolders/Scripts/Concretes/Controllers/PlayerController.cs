using RunSetcanRun.Abstracts.Inputs;
using RunSetcanRun.Animations;
using RunSetcanRun.Combats;
using RunSetcanRun.Inputs;
using RunSetcanRun.Movements;
using RunSetcanRun.Uis;
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
        DisplayScore _displayScore;

        public void Awake()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _mover = GetComponent<Mover>();
            _flip = GetComponent<Flip>();
            _jump = GetComponent<Jump>();
            _onGround = GetComponent<OnGround>();
            _health = GetComponent<Health>();
            _displayScore = FindObjectOfType<DisplayScore>();
            _input = new PcInput();
 
        }

        private void OnEnable()
        {
            GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();
            if(gameCanvas != null)
            {
                _health.OnDead += gameCanvas.ShowGameOverPanel;
                DisplayHealth displayHealth = gameCanvas.GetComponentInChildren<DisplayHealth>();
                _health.OnHealthChanged += displayHealth.WriteHealth;
            }

        }

        public void Update()
        {
            if (_health.IsDead) return;

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
            if (collision.gameObject.tag == "tag_final_collider" && GameManager.Instance.score >= 20)
            {
                GameManager.Instance.LoadScene(1);
                GameManager.Instance.score = 0;
                _displayScore.HandleScoreChanged(0);
            }
        }


    }
}
