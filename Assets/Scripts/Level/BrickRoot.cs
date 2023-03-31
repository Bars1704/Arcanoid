using System;
using System.Linq;
using Bricks.Brick;
using UnityEngine;

namespace Level
{
    public class BrickRoot : MonoBehaviour
    {
        public event Action OnAllBrickDestroyed;
        private IBrick[] _bricks;

        void Start()
        {
            _bricks = GetComponentsInChildren<IBrick>();
            InitBricks();
        }

        private void InitBricks()
        {
            foreach (var brick in _bricks)
            {
                brick.OnBrickDestroyed += OnBrickDestroyed;
            }
        }

        private void OnBrickDestroyed()
        {
            if (_bricks.All(x => x.IsDestroyed))
                OnAllBrickDestroyed?.Invoke();
        }
    }
}