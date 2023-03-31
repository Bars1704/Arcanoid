using System;
using Reflex.Scripts.Attributes;
using ScreenBounds;
using Size;
using UnityEngine;

namespace Ball
{
    [RequireComponent(typeof(IResizable), typeof(ConstantMove))]
    public class ReflectOnBounds : MonoBehaviour
    {
        private Transform _transform;
        private ConstantMove _constantMove;
        private IResizable _resizable;
        private IScreenBoundsService _screenBoundsService;

        private void Awake()
        {
            _transform = transform;
            _resizable = GetComponent<IResizable>();
            _constantMove = GetComponent<ConstantMove>();
        }

        [Inject]
        private void Inject(IScreenBoundsService screenBoundsService)
        {
            _screenBoundsService = screenBoundsService;
        }

        private void ReflectY()
        {
            var newDirection = _constantMove.Direction;
            newDirection.y *= -1;
            _constantMove.Direction = newDirection;
        }

        private void ReflectX()
        {
            var newDirection = _constantMove.Direction;
            newDirection.x *= -1;
            _constantMove.Direction = newDirection;
        }

        private void LateUpdate()
        {
            var side = _screenBoundsService.IsInsideBounds(_transform.position, _resizable);
            if (side != Side.None)
                _transform.position = _screenBoundsService.ClampPosition(_transform.position, _resizable);
            switch (side)
            {
                case Side.Top:
                    ReflectY();
                    break;
                case Side.Bottom:
                    ReflectY();
                    break;
                case Side.Right:
                    ReflectX();
                    break;
                case Side.Left:
                    ReflectX();
                    break;
                case Side.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}