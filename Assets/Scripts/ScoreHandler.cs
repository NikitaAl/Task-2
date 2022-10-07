using UnityEngine;


namespace Assets.Scripts
{
    public class ScoreHandler : MonoBehaviour
    {
        [SerializeField] private Wall[] _walls;
        
        [SerializeField] private GameObject WinScreen;
        [SerializeField] private GameObject PlayScreen;

        private int count;
        
        private void Start() {
            foreach (var wall in _walls)
                wall.OnWallCalorChange.AddListener(OnWallCalorChange);
        }
        private void OnWallCalorChange()
        {
            count++;
            Debug.Log(count);
            if (count >= 2)
            {
                Debug.Log("Win");
                WinScreen.SetActive(true);
                PlayScreen.SetActive(false);
            }
        }
    }

}