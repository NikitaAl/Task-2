using UnityEngine;


namespace Assets.Scripts
{
    public class ScoreHandler : MonoBehaviour
    {
        [SerializeField] private Wall[] _walls;
        [SerializeField] private Win _win;

        private int count;
        
        private void Start() 
        {
            foreach (var wall in _walls)
                wall._OnWallCalorChange.AddListener(OnWallCalorChange);
        }
        
        private void OnWallCalorChange()
        {
            count++;
            Debug.Log(count);
            if (count >= 2)
            {
                Debug.Log("Win");
                _win.YouWin();
            }
        }
    }

}