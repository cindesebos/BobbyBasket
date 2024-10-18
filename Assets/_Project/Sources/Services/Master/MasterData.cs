using UnityEngine;

namespace Sources.Services.Master
{
    [System.Serializable]
    public class MasterData
    {
        [SerializeField] private float _volume;

        public MasterData(float volume) => _volume = volume;

        public float GetVolume() => _volume;
    }
}