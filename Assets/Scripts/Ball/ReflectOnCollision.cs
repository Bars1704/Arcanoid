using UnityEngine;

namespace Ball
{
    [RequireComponent(typeof(ConstantMove))]
    public class ReflectOnCollision : MonoBehaviour
    {
        private ConstantMove _constantMove;

        private void Start()
        {
            _constantMove = GetComponent<ConstantMove>();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            _constantMove.Direction = col.contacts[0].normal;
        }
    }
}