using UnityEngine;
using Zenject;

namespace Sources.Gameplay.Character
{
    [RequireComponent(typeof(CharacterMovement))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterData _data;
        [SerializeField] private CharacterMovement _movement;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private CharacterInput _input;

        [Inject]
        private void Construct(CharacterInput input)
        {
            _input = input;
        }

        private void OnValidate()
        {
            _movement ??= GetComponent<CharacterMovement>();
            _rigidbody2D ??= GetComponent<Rigidbody2D>();
        }

        private void OnEnable() => _input.Enable();

        private void OnDisable() => _input.Disable();

        private void Start()
        {
            _movement.Init(_data, _input, _rigidbody2D);
        }
    }
}
