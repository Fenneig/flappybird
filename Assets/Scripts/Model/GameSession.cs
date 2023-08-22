using UnityEngine;

namespace Flappybird.Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private DifficultSettings _defaultDifficult; 
        
        public static GameSession Instance;

        public DifficultSettings Difficult { get; set; }

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(this);

            Difficult = _defaultDifficult;
        }
    }
}