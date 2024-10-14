using UnityEngine;

namespace Sources.Gameplay.Items
{
    public class ItemMover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody2D _rigidbody2D;

        private void Awake() => _rigidbody2D = GetComponent<Rigidbody2D>();

        private void FixedUpdate() => Move();

        private void Move() => _rigidbody2D.velocity = new Vector2(0, -_speed);
    }
}
