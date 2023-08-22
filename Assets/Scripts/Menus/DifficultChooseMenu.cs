using Flappybird.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Flappybird.Menus
{
    public class DifficultChooseMenu : MonoBehaviour
    {
        [SerializeField] private string _gameplaySceneName; 
        
        public void OnChooseDifficult(DifficultSettings settings)
        {
            Difficult.Current = settings;
            SceneManager.LoadScene(_gameplaySceneName);
        }
    }
}