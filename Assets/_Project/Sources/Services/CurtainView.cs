using UnityEngine;

namespace Sources.Services
{
    public class CurtainView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        public void Show()
        {
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            _canvasGroup.alpha = 0;
            gameObject.SetActive(false);
        }
    }
}