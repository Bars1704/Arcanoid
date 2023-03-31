using UnityEngine;

namespace Ball
{
    public class ConstantMove : MonoBehaviour
    {
        public float Velocity { get; set; }

        private Vector2 _direction;

        public Vector2 Direction
        {
            get => _direction;
            set => _direction = value.normalized;
        }
    
        private void Update()
        {
            transform.Translate(Direction * (Velocity * Time.deltaTime));
        }
    }
}