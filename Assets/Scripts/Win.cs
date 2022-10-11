using UnityEngine;

namespace Assets.Scripts
{
    public class Win : MonoBehaviour
    {
        [SerializeField] private GameObject _winScreen;
        [SerializeField] private GameObject _playScreen;

        public void YouWin()
        {
            _winScreen.SetActive(true);
            _playScreen.SetActive(false);
        }
    }
}