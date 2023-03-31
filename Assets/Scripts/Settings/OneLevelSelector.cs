using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "Arcanoid/OneLevelSelector")]
    public class OneLevelSelector : ScriptableObject, ILevelSelector
    {
        [SerializeField] private LevelSettings _level;
        public LevelSettings GetNextLevel() => _level;
        public LevelSettings Current => _level;
    }
}