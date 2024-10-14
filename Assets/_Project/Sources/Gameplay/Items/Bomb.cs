using UnityEngine;

namespace Sources.Gameplay.Items
{
    public sealed class Bomb : Item
    {
        public override void PickUp()
        {
            Debug.Log($"Character picked up a bomb");
        }
    }
}