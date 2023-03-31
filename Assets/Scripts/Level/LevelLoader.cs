using System;
using Ball;
using Player;
using Reflex.Scripts.Attributes;
using Settings;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level
{
    public class LevelLoader : MonoBehaviour, ILevelLoader
    {
        [Header("Ball")] [SerializeField] private Transform _ballRootPos;
        [SerializeField] private ConstantMove _ball;

        [Header("Player")] [SerializeField] private Transform _playerRootPos;
        [SerializeField] private MoveByInput _player;

        [Header("Bricks")] [SerializeField] private Transform _brickRoot;
        private BrickRoot _currentBrickRoot;

        [SerializeField] private LevelGameLoopMediator _levelGameLoopMediator;

        private LevelSettings _levelSettings;

        public void Init(LevelSettings newLevel)
        {
            _levelSettings = newLevel;
            InitBricks();
            InitPlayer();
            InitBall();
            _levelGameLoopMediator.Init(_currentBrickRoot);
        }

        private void InitPlayer()
        {
            _player.transform.position = _playerRootPos.position;
            _player.Init(_levelSettings);
        }

        private void InitBall()
        {
            _ball.transform.position = _ballRootPos.transform.position;
            _ball.Velocity = 0;
            _ball.Direction = Vector2.zero;
        }

        private void InitBricks()
        {
            if (_currentBrickRoot != default)
            {
                Destroy(_currentBrickRoot);
                _currentBrickRoot = default;
            }

            _currentBrickRoot = Instantiate(_levelSettings.BrickRootPrefab, _brickRoot);
        }

        public void StartGame()
        {
            LaunchBall();
        }

        private void LaunchBall()
        {
            _ball.Velocity = _levelSettings.BallMovingSpeed;
            var ballDirection = Random.insideUnitCircle;
            ballDirection.y = Math.Max(ballDirection.y, 0.1f);
            _ball.Direction = ballDirection;
        }
    }
}