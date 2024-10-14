using UnityEngine;

namespace Sources.Gameplay.Character
{
    [CreateAssetMenu(menuName = "Source/Datas/Character", fileName = "CharacterData", order = 0)]
    public class CharacterData : ScriptableObject
    {
        [SerializeField] private float _speed;

        public float Speed => _speed;
    }
}