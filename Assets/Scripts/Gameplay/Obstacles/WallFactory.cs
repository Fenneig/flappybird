using System.Collections;
using Flappybird.Model;
using UnityEngine;

namespace Flappybird.Gameplay.Obstacles
{
    public class WallFactory : MonoBehaviour
    {
        [SerializeField] private float _rangeBetweenSpawns;
        [SerializeField] private Wall _wallPrefab;
        
        private float _timeBetweenSpawns;
        private bool _isPlaying;

        private void Start()
        {
            _isPlaying = true;
            _timeBetweenSpawns = _rangeBetweenSpawns / Difficult.Current.WallSpeed;
            StartCoroutine(SpawnWall());
        }

        private IEnumerator SpawnWall()
        {
            while (_isPlaying)
            {
                var wall = Instantiate(_wallPrefab, transform.position, Quaternion.identity);
                wall.Init();

                yield return new WaitForSeconds(_timeBetweenSpawns);
            }
        }
    }
}