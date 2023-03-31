using System;
using UnityEngine;

namespace Input
{
    public class DesktopPlayerInput : MonoBehaviour, IPlayerInput
    {
        public event Action<float> OnPlayerMoveX;

        private void Update()
        {
            var axis = UnityEngine.Input.GetAxis("Horizontal");
            if (axis != 0)
                OnPlayerMoveX?.Invoke(axis);
        }
    }
}