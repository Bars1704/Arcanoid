using System;
using UnityEngine;

namespace Bricks.Brick
{
    public abstract class BrickBase : MonoBehaviour, IBrick
    {
        public event Action OnBrickDestroyed;
        public bool IsDestroyed { get; private set; }

        public abstract void OnBrickCollided();

        protected void DestroyBrick()
        {
            IsDestroyed = true;
            OnBrickDestroyed?.Invoke();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnBrickCollided();
        }
    }
}