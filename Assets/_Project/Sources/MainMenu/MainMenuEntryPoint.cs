using Sources.Services.Score;
using TMPro;
using UnityEngine;
using Zenject;

namespace Sources.MainMenu
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _maxScoreText;

        private IScoreService _scoreService;

        [Inject]
        private void Construct(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        private void Awake()
        {
            _maxScoreText.text = _scoreService.MaxScore.ToString();
        }
    }
}