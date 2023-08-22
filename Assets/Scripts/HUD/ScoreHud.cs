using Flappybird.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Flappybird.HUD
{
    public class ScoreHud : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;

        private void Start()
        {
            GameSession.Instance.Score.OnChanged += OnScoreChanged;
            _scoreText.text = "Score: 0";
        }

        private void OnDestroy()
        {
            GameSession.Instance.Score.OnChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int newvalue, int oldvalue)
        {
            _scoreText.text = $"Score: {newvalue}";
        }
    }
}