using System;
using UnityEngine;

namespace Code.Vehicle
{
    public class WheelGroundCheck : MonoBehaviour
    {
        public bool IsGrounded
        {
            private set
            {
                if (_isGrounded != value)
                {
                    _isGrounded = value;

                    if(debugSprite != null)
                        debugSprite.color = _isGrounded ? Color.green : Color.red;
                }
            }
            
            get => _isGrounded;
        }
        private bool _isGrounded;

        private float _timer;
        private bool _isColliderGrounded;
        
        [SerializeField] private string groundTag = "Ground";
        [SerializeField] private SpriteRenderer debugSprite;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag(groundTag))
            {
                _isColliderGrounded = true;
                IsGrounded = true;
                _timer = 0;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.collider.CompareTag(groundTag))
            {
                _isColliderGrounded = false;
            }
        }

        private void Update()
        {
            if (!_isColliderGrounded)
            {
                _timer += Time.deltaTime;
                if (_timer >= 0.25f)
                {
                    IsGrounded = false;
                }
            }
        }
    }
}
