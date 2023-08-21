using Flappybird.Model.Data;
using UnityEngine;

namespace Flappybird.Menus.UI
{
    public class AudioSettingsUIComponent : MonoBehaviour
    {
        [Header("Widgets")]
        [SerializeField] private AudioSettingsWidget _musicWidget;
        [SerializeField] private AudioSettingsWidget _effectsWidget;

        private void Awake()
        {
            _musicWidget.SetModel(GameSettings.I.Music);
            _effectsWidget.SetModel(GameSettings.I.Effects);
        }
    }
}