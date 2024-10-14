using UnityEngine;

namespace Sources.Gameplay.Items
{
    [RequireComponent(typeof(ItemMover))]
    public abstract class Item : MonoBehaviour
    {
        public virtual void PickUp() { }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Character.Character>()) PickUp();

            gameObject.SetActive(false);
        }
    }
}
