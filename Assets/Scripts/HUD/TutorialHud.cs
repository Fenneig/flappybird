using Flappybird.Model;
using UnityEngine;

namespace Flappybird.HUD
{
    public class TutorialHud : MonoBehaviour
    {
        private void Awake()
        {
            GameSession.Instance.PauseService.SetPause(true);
        }

        private void Update()
        {
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0)) StartGame();
#elif PLATFORM_ANDROID
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    StartGame();
                }
            }
#endif
        }

        private void StartGame()
        {
            GameSession.Instance.PauseService.SetPause(false);
            gameObject.SetActive(false);
        }
    }
}