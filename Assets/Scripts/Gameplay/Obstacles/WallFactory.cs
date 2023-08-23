using System.Collections;
using Flappybird.Model;
using Flappybird.Pause;
using UnityEngine;

namespace Flappybird.Gameplay.Obstacles
{
    public class WallFactory : MonoBehaviour, IPausable
    {
        [SerializeField] private float _rangeBetweenSpawns;
        [SerializeField] private Wall _wallPrefab;
        
        private float _timeBetweenSpawns;
        private bool _isPlaying;

        private void Start()
        {
            _timeBetweenSpawns = _rangeBetweenSpawns / Difficult.Current.WallSpeed;
            GameSession.Instance.PauseService.Register(this);
        }

        private void OnDestroy()
        {
            GameSession.Instance.PauseService.Unregister(this);
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

            /*TODO: Тут будет баг т.к. время между спаунами стенок не учитывается, то при отпускании паузы сразу будет спаунится следующая стена.
              TODO: я обычно для подобных штук пишу свой таймер который учитывает это, но в ТЗ не входила задача делать полноценную паузу, 
              TODO: так что данная задача в бэклог отправляется */
            
        public void SetPause(bool isPaused)
        {
            _isPlaying = !isPaused;
            
            if (!isPaused) StartCoroutine(SpawnWall());
        }
    }
}