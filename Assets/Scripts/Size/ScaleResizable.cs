using System;
using UnityEngine;

namespace Size
{
    public class ScaleResizable : MonoBehaviour, IResizable
    {
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public Vector2 Size
        {
            get => _transform.localScale;
            set => _transform.localScale = value;
        }
    }
}