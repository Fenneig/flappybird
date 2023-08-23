using Flappybird.Audio;
using Flappybird.Components.Gameplay;
using Flappybird.Model;
using Flappybird.Pause;
using UnityEngine;

namespace Flappybird.Gameplay.Player
{
    public class Bird : MonoBehaviour, IPausable
    {
        [Header("Settings")]
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private float _maxJumpVelocity;
        [Space, Header("Components")]
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private PlaySoundsComponent _soundsComponent;
        [Space, Header("String constants")]
        [SerializeField] private string _flapSoundId;
        [SerializeField] private string _dieSoundId;

        private bool _isPaused;

        private void Start()
        {
            GameSession.Instance.PauseService.Register(this);
            _rigidbody.simulated = false;
        }

        private void Update()
        {
            if (_isPaused) return;
#if UNITY_EDITOR || PLATFORM_STANDALONE
            if (Input.GetMouseButtonDown(0)) Jump();
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

        private void OnDestroy()
        {
            GameSession.Instance.PauseService.Unregister(this);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<LoseComponent>(out var loseComponent))
            {
                loseComponent.Lose();
                _soundsComponent.Play(_dieSoundId);

                _collider.enabled = false;
            }
        }

        private void Jump()
        {
            _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            _soundsComponent.Play(_flapSoundId);
            
            if (_rigidbody.velocity.y > _maxJumpVelocity) _rigidbody.velocity = new Vector2(0, _maxJumpVelocity);
        }

        public void SetPause(bool isPaused)
        {
            _isPaused = isPaused;
            
            if (!_isPaused) _rigidbody.simulated = true;
        }
    }
}