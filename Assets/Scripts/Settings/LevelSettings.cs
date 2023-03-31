using Level;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "Arcanoid/LevelSettings")]
    public class LevelSettings : ScriptableObject
    {
        public float PlayerMovingSpeed;
        public float BallMovingSpeed;
        public BrickRoot BrickRootPrefab;
    }
}