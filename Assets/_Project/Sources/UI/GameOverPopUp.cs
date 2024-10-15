using UnityEngine;

namespace Sources.UI
{
    public class GameOverPopUp : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToShow;

        public void Show()
        {
            _objectToShow.SetActive(true);
        }
    }
}
