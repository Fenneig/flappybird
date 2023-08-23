using UnityEngine;

namespace Flappybird.Utils
{
    public static class WindowUtils
    {
        private static GameObject _window;
        private static Canvas _canvas;
        
        private static GameObject CreateWindow()
        {
            return Object.Instantiate(_window, _canvas.transform);
        }

        public static GameObject CreateWindow(string resourcePath)
        {
            _window = Resources.Load<GameObject>(resourcePath);
            _canvas = GameObject.FindWithTag("MainHUDCanvas").GetComponent<Canvas>();
            
            return CreateWindow();
        }
    }
}