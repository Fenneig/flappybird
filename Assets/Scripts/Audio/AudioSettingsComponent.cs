using System;
using Flappybird.Model.Data;
using Flappybird.Model.Data.Properties;
using UnityEngine;

namespace Flappybird.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSettingsComponent : MonoBehaviour
    {
        [SerializeField] SoundSettings _mode;
        private AudioSource _source;
        private FloatPersistentProperty _model;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
            _model = FindProperty();
            _model.OnChanged += OnSoundSettingsChange;

            OnSoundSettingsChange(_model.Value, _model.Value);
        }

        private void OnSoundSettingsChange(float newValue, float _)
        {
            _source.volume = newValue;
        }

        private FloatPersistentProperty FindProperty()
        {
            switch (_mode)
            {
                case SoundSettings.Music: return GameSettings.I.Music;
                case SoundSettings.Effects: return GameSettings.I.Effects;
            }
            throw new ArgumentException($"Undefined argument! Check if you forget to change Sound settings mode from Master on {gameObject.name} object");
        }

        private void OnDestroy()
        {
            _model.OnChanged -= OnSoundSettingsChange;
        }
    }
}