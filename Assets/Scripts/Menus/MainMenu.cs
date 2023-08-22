using UnityEngine;

namespace Flappybird.Menus
{
    public class MainMenu : MonoBehaviour
    {
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