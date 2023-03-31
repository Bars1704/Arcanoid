using System;

namespace Input
{
    public interface IPlayerInput
    {
        public event Action<float> OnPlayerMoveX;
    }
}