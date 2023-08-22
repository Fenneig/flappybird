using Flappybird.Model;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Flappybird.Gameplay.Obstacles
{
    public class Wall : MonoBehaviour
    {
        [SerializeField] private GameObject _topWall;
        [SerializeField] private GameObject _botWall;
        
        private float _speed;
        private float _gapAppearRange;

        private const float MAX_GAP_RANGE = 4f;

        public void Init()
        {
            _speed = Difficult.Current.WallSpeed;
            _topWall.transform.position += Vector3.up * Difficult.Current.WallGapSize;
            _botWall.transform.position += Vector3.down * Difficult.Current.WallGapSize;
            _gapAppearRange = MAX_GAP_RANGE - Difficult.Current.WallGapSize;
            transform.position += Vector3.up * Random.Range(-_gapAppearRange, _gapAppearRange);
        }

        private void Update()
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GameSession.Instance.Score.Value++;
            }
        }
    }
}