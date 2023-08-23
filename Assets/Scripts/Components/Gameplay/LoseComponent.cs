using Flappybird.Model;
using Flappybird.Utils;
using UnityEngine;

namespace Flappybird.Components.Gameplay
{
    public class LoseComponent : MonoBehaviour
    {
        public void Lose()
        {
            GameSession.Instance.PauseService.SetPause(true);
            WindowUtils.CreateWindow("HUD/Windows/LoseWindow");
        }
    }
}