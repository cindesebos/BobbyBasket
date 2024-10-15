using UnityEngine;
using DG.Tweening;
using TMPro;

namespace Sources.UI
{
    public class GameOverPopUp : MonoBehaviour
    {
        [SerializeField] private float _showEffectDuration;
        [Space]

        [SerializeField] private GameObject _objectToShow;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private TextMeshProUGUI _scoreText;

        private void Start()
        {
            _canvasGroup.alpha = 0f;
            _objectToShow.SetActive(false);
        }

        public void Show(int score)
        {
            _scoreText.text += score.ToString();
            _objectToShow.SetActive(true);
            _canvasGroup.DOFade(1f, _showEffectDuration).SetEase(Ease.InOutQuad);
        }
    }
}
