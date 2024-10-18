using Sources.Services.Master;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Sources.MainMenu
{
    public class MasterVolumeHandler : MonoBehaviour
    {
        private const string _masterKey = "Master";

        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private Slider _masterSlider;

        private IMasterService _masterService;

        public void Init(IMasterService masterService)
        {
            _masterService = masterService;

            OnMasterVolumeChanged(_masterService.Volume);
        }

        public void OnMasterVolumeChanged(float value)
        {
            _audioMixer.SetFloat(_masterKey, value);

            _masterService.Volume = value;
        }
    }
}
