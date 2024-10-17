using UnityEngine;
using Zenject;

namespace Sources.Gameplay.Items
{
    public class ItemsSFX
    {
        private readonly AudioSource _audioSource;

        private readonly AudioClip _pickUpCoin, _pickUpBomb;

        [Inject]
        public ItemsSFX(AudioSource audioSource, ItemsSFXData data)
        {
            _audioSource = audioSource;

            _pickUpCoin = data.PickUpCoin;
            _pickUpBomb = data.PickUpBomb;
        }

        public void PlayPickUpCoinSound() => _audioSource.PlayOneShot(_pickUpCoin);

        public void PlayPickUpBombSound() => _audioSource.PlayOneShot(_pickUpBomb);

    }
}