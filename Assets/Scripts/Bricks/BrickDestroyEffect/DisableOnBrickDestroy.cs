using Bricks.Brick;
using UnityEngine;

namespace Bricks.BrickDestroyEffect
{
    [RequireComponent(typeof(IBrick))]
    public class DisableOnBrickDestroy : MonoBehaviour
    {
        private IBrick _brick;

        private void Start()
        {
            _brick = GetComponent<IBrick>();
            _brick.OnBrickDestroyed += Disable;
        }

        private void OnDestroy()
        {
            _brick.OnBrickDestroyed -= Disable;
        }

        private void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}