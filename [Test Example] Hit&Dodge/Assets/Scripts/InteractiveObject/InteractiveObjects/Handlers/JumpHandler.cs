using System.Threading.Tasks;
using Implementations.Other;
using UnityEngine;

namespace InteractiveObjects.Handlers
{
    public class JumpHandler : AbstractHandler
    {
        [SerializeField,Header("Mask Settings")] private LayerMask _groundMask;
        [SerializeField,Header("Animator")] private Animator _animator;
        private Rigidbody2D _rigidbody2D;
        public bool _isGrounded { get; private set; }

        private void OnEnable()
        {
          _rigidbody2D = GetComponentInParent<Rigidbody2D>();
        }

        private void Update()
        {
            _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.3f, _groundMask);
            
            if(_isGrounded) Jump();

            if (!_isGrounded)
            {
                _animator.SetBool("IsOnAGround", false);
            }
            else
            {
                _animator.SetBool("IsOnAGround", true);
            }
            
        }

        private async void Jump()
        {
            if (Input.GetButtonDown("up")){
                if (_rigidbody2D != null) _rigidbody2D.AddForce( Vector2.up*8f, ForceMode2D.Impulse);
            }

            await Task.Delay(100);
        }
    }
}

