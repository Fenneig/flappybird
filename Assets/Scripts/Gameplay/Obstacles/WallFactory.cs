using System.Collections;
using Flappybird.Model;
using UnityEngine;

namespace Flappybird.Gameplay.Obstacles
{
    public class WallFactory : MonoBehaviour
    {
        [SerializeField] private float _rangeBetweenSpawns;
        [SerializeField] private Wall _wallPrefab;
        private DifficultSettings Difficult => GameSession.Instance.Difficult;
        private float _timeBetweenSpawns;
        private bool _isPlaying;

        private void Start()
        {
            _isPlaying = true;
            _timeBetweenSpawns = _rangeBetweenSpawns / Difficult.WallSpeed;
            StartCoroutine(SpawnWall());
        }

        private IEnumerator SpawnWall()
        {
            while (_isPlaying)
            {
                var wall = Instantiate(_wallPrefab, transform.position, Quaternion.identity);
                wall.Init(Difficult);

                yield return new WaitForSeconds(_timeBetweenSpawns);
            }
        }
    }
}