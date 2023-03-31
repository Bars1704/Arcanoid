using Input;
using Reflex.Scripts.Attributes;
using ScreenBounds;
using Settings;
using Size;
using UnityEditor;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(IResizable))]
    public class MoveByInput : MonoBehaviour
    {
        private Transform _transform;
        private IPlayerInput _playerInput;
        private IScreenBoundsService _screenBoundsService;
        private IResizable _resizable;

        private float _speed;

        private void Start()
        {
            _transform = transform;
            _resizable = GetComponent<IResizable>();
        }

        [Inject]
        public void Inject(IPlayerInput playerInput, IScreenBoundsService screenBoundsService)
        {
            _playerInput = playerInput;
            _screenBoundsService = screenBoundsService;
            playerInput.OnPlayerMoveX += Move;

            _screenBoundsService.RecalculateBounds();
        }

        public void Init(LevelSettings playerSettings)
        {
            _speed = playerSettings.PlayerMovingSpeed;
        }

        private void Move(float delta)
        {
            var position = _transform.position;
            var moveDelta = Vector3.right * (delta * _speed * Time.deltaTime);

            var newPos = position + moveDelta;

            _transform.position = _screenBoundsService.ClampPosition(newPos, _resizable);
        }
    }
}