using System;
using UnityEngine;

namespace Misc
{
    public class TriggerEvent : MonoBehaviour
    {
        public event Action OnTriggerEnter;
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnter?.Invoke();
        }
    }
}
