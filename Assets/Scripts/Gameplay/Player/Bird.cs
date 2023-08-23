using Flappybird.Audio;
using UnityEngine;

namespace Flappybird.Gameplay.Player
{
    public class Bird : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private float _maxJumpVelocity;
        [Space, Header("Components")]
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private PlaySoundsComponent _soundsComponent;
        [Space, Header("String constants")]
        [SerializeField] private string _flapSoundId;

        private void Update()
        {
#if UNITY_EDITOR

            if (Input.GetMouseButtonDown(0))
                Jump();
#elif PLATFORM_ANDROID
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    Jump();
                }
            }
#endif
        }

        private void Jump()
        {
            _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            _soundsComponent.Play(_flapSoundId);
            
            if (_rigidbody.velocity.y > _maxJumpVelocity) _rigidbody.velocity = new Vector2(0, _maxJumpVelocity);
        }
    }
}