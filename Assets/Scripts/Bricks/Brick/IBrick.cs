using System;

namespace Bricks.Brick
{
    public interface IBrick
    {
        public event Action OnBrickDestroyed;
        public bool IsDestroyed { get; }
    }
}