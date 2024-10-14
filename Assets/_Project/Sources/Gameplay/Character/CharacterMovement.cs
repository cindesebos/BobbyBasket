using UnityEngine;

namespace Sources.Gameplay.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        private float _speed;

        private float _moveInputX;

        private CharacterData _data;
        private CharacterInput _input;
        private Rigidbody2D _rigidbody2D;

        public void Init(CharacterData data, CharacterInput input, Rigidbody2D rigidbody2D)
        {
            _data = data;
            _input = input;
            _rigidbody2D = rigidbody2D;

            _speed = _data.Speed;
        }

        private void Update()
        {
            _moveInputX = ReadMoveInput().x;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move() => _rigidbody2D.velocity = new Vector2(_moveInputX * _speed, _rigidbody2D.velocity.y);

        private Vector2 ReadMoveInput() => _input.Movement.Move.ReadValue<Vector2>();
    }
}
