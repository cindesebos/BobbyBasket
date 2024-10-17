using UnityEngine;
using Zenject;

namespace Sources.Gameplay.Items
{
    [RequireComponent(typeof(ItemMover))]
    public abstract class Item : MonoBehaviour
    {
        private ItemsSFX _itemsSFX;

        protected virtual void Construct(ItemsSFX itemsSFX)
        {
            _itemsSFX = itemsSFX;
        }

        public virtual void PickUp() { }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Character.Character>())
            {
                PickUp();

                PlaySound();
            }

            gameObject.SetActive(false);
        }

        public void PlaySound()
        {
            if (this is Coin) _itemsSFX.PlayPickUpCoinSound();
            else if (this is Bomb) _itemsSFX.PlayPickUpBombSound();
        }
    }
}
