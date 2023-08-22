using UnityEngine;
using UnityEngine.SceneManagement;

namespace Flappybird.HUD
{
    public class ExitButton : MonoBehaviour
    {
        [SerializeField] private string _menuSceneName;

        public void OnExit()
        {
            SceneManager.LoadScene(_menuSceneName);
        }
    }
}