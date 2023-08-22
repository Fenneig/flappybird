using Flappybird.Model.Data.Properties;
using UnityEngine;

namespace Flappybird.Model.Data
{
    [CreateAssetMenu(menuName = "Data/GameSettings", fileName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private FloatPersistentProperty _music;
        [SerializeField] private FloatPersistentProperty _effects;

        public FloatPersistentProperty Music => _music;
        public FloatPersistentProperty Effects => _effects;

        private static GameSettings _instance;
        public static GameSettings I => _instance == null ? LoadGameSettings() : _instance;
        
        private const float DEFAULT_SOUND_VALUE = .2f;

        private static GameSettings LoadGameSettings()
        {
            return _instance = Resources.Load<GameSettings>("GameSettings");
        }

        private void OnEnable()
        {
            _music = new FloatPersistentProperty(DEFAULT_SOUND_VALUE, SoundSettings.Music.ToString());
            _effects = new FloatPersistentProperty(DEFAULT_SOUND_VALUE, SoundSettings.Effects.ToString());
        }

        private void OnValidate()
        {
            _music.Validate();
            _effects.Validate();
        }
    }

    public enum SoundSettings 
    {
        Music,
        Effects
    }
}