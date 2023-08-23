using UnityEngine;

namespace Flappybird.Menus
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private int _applicationFrameRate;
        
        private void Start()
        {
            Application.targetFrameRate = _applicationFrameRate;
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