using System;
using Misc;
using UnityEngine;

namespace Level
{
    public class LevelGameLoopMediator : MonoBehaviour, ILevelWinMonitor, ILevelLoseMonitor
    {
        public event Action OnLevelWin;
        public event Action OnLevelLose;

        [SerializeField] private TriggerEvent _deadZone;

        private BrickRoot _brickRoot;


        public void Init(BrickRoot brickRoot)
        {
            if (_brickRoot != default)
                _brickRoot.OnAllBrickDestroyed -= WinGame;
            _brickRoot = brickRoot;
            _brickRoot.OnAllBrickDestroyed += WinGame;
        }

        private void Start()
        {
            _deadZone.OnTriggerEnter += LoseGame;
            _brickRoot.OnAllBrickDestroyed += WinGame;
        }

        private void OnDestroy()
        {
            _deadZone.OnTriggerEnter -= LoseGame;
            _brickRoot.OnAllBrickDestroyed -= WinGame;
        }

        private void LoseGame()
        {
            OnLevelLose?.Invoke();
        }

        private void WinGame()
        {
            OnLevelWin?.Invoke();
        }
    }
}