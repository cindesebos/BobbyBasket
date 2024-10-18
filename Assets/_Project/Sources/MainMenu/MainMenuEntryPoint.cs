using Sources.Services.Master;
using Sources.Services.Score;
using TMPro;
using UnityEngine;
using Zenject;

namespace Sources.MainMenu
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private MasterVolumeHandler _masterVolumeHandler;
        [Space]
        
        [SerializeField] private TextMeshProUGUI _maxScoreText;

        private IScoreService _scoreService;
        private IMasterService _masterService;

        [Inject]
        private void Construct(IScoreService scoreService, IMasterService masterService)
        {
            _scoreService = scoreService;
            _masterService = masterService;
        }

        private void Awake()
        {
            _masterVolumeHandler.Init(_masterService);

            _maxScoreText.text = _scoreService.MaxScore.ToString();
        }
    }
}