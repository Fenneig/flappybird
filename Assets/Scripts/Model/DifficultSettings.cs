using UnityEngine;

namespace Flappybird.Model
{
    [CreateAssetMenu(fileName = "Difficult", menuName = "Settings/Difficult")]
    public class DifficultSettings : ScriptableObject
    {
        [SerializeField] [Range(1.0f, 4.0f)] private float _wallGapSize;
        [SerializeField] [Range(2.0f, 10.0f)] private float _wallSpeed;

        public float WallGapSize => _wallGapSize;
        public float WallSpeed => _wallSpeed;
    }
}