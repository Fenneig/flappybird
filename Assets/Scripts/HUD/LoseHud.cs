using Flappybird.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Flappybird.HUD
{
    public class LoseHud : MonoBehaviour
    {
        [SerializeField] private Text _loseText;

        private void Awake()
        {
            _loseText.text += GameSession.Instance.Score.Value;
        }
    }
}