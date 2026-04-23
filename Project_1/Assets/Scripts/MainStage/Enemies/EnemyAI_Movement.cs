using UnityEngine;

namespace MainStage.Enemies
{
    public class EnemyAIMovement : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 5;
    
        Vector2 _direction;
        Rigidbody2D _rb;
        Transform _target;
    
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();        
            _target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    
        void FixedUpdate()
        {
            if (_target)
            {
                _direction = ((Vector2)_target.position - _rb.position).normalized; //get the direction of the player
                _rb.linearVelocity = _direction * moveSpeed;
            }
            else
            {
                _rb.linearVelocity = Vector2.zero;
            }
        }
    }
}
