using UnityEngine;
using UnityEngine.SceneManagement;

namespace Flappybird.Menus
{
    public class LoadingMenu : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadSceneAsync("GameScene");
        }
    }
}