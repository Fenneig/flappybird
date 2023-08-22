using Flappybird.Model;
using UnityEngine;

namespace Flappybird.Gameplay.Obstacles
{
    public class Wall : MonoBehaviour
    {
        [SerializeField] private GameObject _topWall;
        [SerializeField] private GameObject _botWall;
        
        private float _speed;
        private float _gapAppearRange;

        private const float MAX_GAP_RANGE = 4f;
        

        public void Init(DifficultSettings difficultSettings)
        {
            _speed = difficultSettings.WallSpeed;
            _topWall.transform.position += Vector3.up * difficultSettings.WallGapSize;
            _botWall.transform.position += Vector3.down * difficultSettings.WallGapSize;
            _gapAppearRange = MAX_GAP_RANGE - difficultSettings.WallGapSize;
            transform.position += Vector3.up * Random.Range(-_gapAppearRange, _gapAppearRange);
        }

        private void Update()
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }
    }
}