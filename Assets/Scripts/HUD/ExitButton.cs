using UnityEngine;
using UnityEngine.SceneManagement;

namespace Flappybird.HUD
{
    public class ExitButton : MonoBehaviour
    {
        public void OnExit()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}