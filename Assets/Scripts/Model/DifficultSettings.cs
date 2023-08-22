using UnityEngine;

namespace Flappybird.Model
{
    [CreateAssetMenu(fileName = "Difficult", menuName = "Settings/Difficult")]
    public class DifficultSettings : ScriptableObject
    {
        [SerializeField] private float _wallGapSize;
        [SerializeField] private float _wallSpeed;

        public float WallGapSize => _wallGapSize;
        public float WallSpeed => _wallSpeed;
    }
}