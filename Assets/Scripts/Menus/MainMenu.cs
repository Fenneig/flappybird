using UnityEngine;
using UnityEngine.SceneManagement;

namespace Flappybird.Menus
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private string _gameplaySceneName; 
        
        public void OnStart()
        {
            SceneManager.LoadScene(_gameplaySceneName);
        }

        public void OnExit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}