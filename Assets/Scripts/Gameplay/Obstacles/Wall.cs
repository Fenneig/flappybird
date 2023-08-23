using Flappybird.Audio;
using Flappybird.Model;
using Flappybird.Pause;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Flappybird.Gameplay.Obstacles
{
    public class Wall : MonoBehaviour, IPausable
    {
        [Header("Sound settings")]
        [SerializeField] private PlaySoundsComponent _soundComponent;
        [SerializeField] private string _soundId;
        [Space,Header("Game objects")]
        [SerializeField] private GameObject _topWall;
        [SerializeField] private GameObject _botWall;

        private float _speed;
        private float _gapAppearRange;
        private bool _isPaused;

        private const float MAX_GAP_RANGE = 4f;

        public void Init()
        {
            _speed = Difficult.Current.WallSpeed;
            _topWall.transform.position += Vector3.up * Difficult.Current.WallGapSize;
            _botWall.transform.position += Vector3.down * Difficult.Current.WallGapSize;
            _gapAppearRange = MAX_GAP_RANGE - Difficult.Current.WallGapSize;
            transform.position += Vector3.up * Random.Range(-_gapAppearRange, _gapAppearRange);
            GameSession.Instance.PauseService.Register(this);
        }

        private void Update()
        {
            if (_isPaused) return;
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GameSession.Instance.Score.Value++;
                _soundComponent.Play(_soundId);
            }
        }

        private void OnDestroy()
        {
            GameSession.Instance.PauseService.Unregister(this);
        }

        public void SetPause(bool isPaused)
        {
            _isPaused = isPaused;
        }
    }
}