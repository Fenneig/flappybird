using Flappybird.Model.Data.Properties;
using Flappybird.Pause;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Flappybird.Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private DifficultSettings _defaultSettings;
            
        public static GameSession Instance;

        public IntProperty Score { get; set; }
        public PauseService PauseService { get; private set; }

        private void Awake()
        {
            GameSession existSession = GetExistSession();

            if (existSession != null)
            {
                existSession.StartSession();
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
                InitModels();
                StartSession();
            }
        }

        private void StartSession()
        {
            Score = new IntProperty();
            LoadHud();
        }

        private GameSession GetExistSession()
        {
            var sessions = FindObjectsOfType<GameSession>();
            foreach (var gameSession in sessions)
            {
                if (gameSession != this)
                    return gameSession;
            }

            return null;
        }

        private void InitModels()
        {
            if (_defaultSettings != null) Difficult.Current = _defaultSettings;
            PauseService = new PauseService();
        }

        private void LoadHud()
        {
            SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
        }
    }
}