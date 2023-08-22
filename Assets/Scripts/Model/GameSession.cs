using Flappybird.Model.Data.Properties;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Flappybird.Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private DifficultSettings _defaultSettings;
            
        public static GameSession Instance;

        public IntProperty Score { get; set; }

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
        }

        private void LoadHud()
        {
            SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
        }
    }
}