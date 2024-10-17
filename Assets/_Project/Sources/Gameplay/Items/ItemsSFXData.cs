using UnityEngine;

namespace Sources.Gameplay.Items
{
    [CreateAssetMenu(menuName = "Source/Datas/ItemsSFX", fileName = "ItemsSFXData", order = 0)]
    public class ItemsSFXData : ScriptableObject
    {
        [SerializeField] private AudioClip _pickUpCoin, _pickUpBomb;

        public AudioClip PickUpCoin => _pickUpCoin;
        public AudioClip PickUpBomb => _pickUpBomb;
    }
}