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
            Instance = this;
            DontDestroyOnLoad(this);
            InitModels();
            LoadHud();
        }

        private void InitModels()
        {
            if (_defaultSettings != null) Difficult.Current = _defaultSettings;
            Score = new IntProperty();
            PauseService = new PauseService();
        }

        private void LoadHud()
        {
            SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
        }
    }
}