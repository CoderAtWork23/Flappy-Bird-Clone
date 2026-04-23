using System;
using MainStage.Stage;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace MainStage.Player
{
    public class FlabbyBoxScript : MonoBehaviour
    {
        [SerializeField] float wingStrength;
    
        LogicManager _logicManager;
        SoundManager _soundManager;
        Animator _wingAnimator;
        BallSpawner _ballSpawner;
    
        CircleCollider2D _circleCollider2D;
        Rigidbody2D _rb;
        bool _isAlive;
    
        public UnityEvent explosion;
        private float _vertical;
        
        void Start()
        {

            _logicManager = GameObject.Find("LogicManager").GetComponent<LogicManager>();
        
            _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        
            _ballSpawner = transform.GetChild(0).GetComponent<BallSpawner>();
        
            _wingAnimator = transform.GetChild(1).GetComponent<Animator>();
        
            _circleCollider2D = GetComponent<CircleCollider2D>();
        
            _rb = GetComponent<Rigidbody2D>();
        
            _isAlive = true;
        
            _soundManager.PlayAliveSong();
        }
        void Update()
        {
            if (!(Math.Abs(transform.position.y) >= 14)) return;
            GameOver();
            Destroy(gameObject);
        }

        #region PlayerControls
             public void Jump(InputAction.CallbackContext context)
             {
                 if (context.performed && _isAlive) 
                 { 
                     _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, wingStrength);
                     _wingAnimator.Play("WingFlap");
                 }
             }

             public void Shoot(InputAction.CallbackContext context)
             {
                 if(context.performed && _isAlive)
                     _ballSpawner.InstantiateBall();
             }
        #endregion


        private void OnCollisionEnter2D(Collision2D collision)
        {
            _isAlive = false;
            _circleCollider2D.enabled = false;

            if (collision.gameObject.CompareTag("Enemy"))
            {
                explosion.Invoke();
                Destroy(gameObject);
            }
            else
            {
                _soundManager.PlayDeathSound();
            }

            GameOver();
        }

        private void GameOver()
        {
            _rb.gravityScale = 10;
            _soundManager.StopAliveSong();
            _logicManager.GameOver(); //if you notice, anything the bird collides with is an instant game over
        }
    }
}
