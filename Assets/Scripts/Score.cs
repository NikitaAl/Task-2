using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    public class Score : MonoBehaviour
    {
        public TMP_Text _TextScore;

        private int _scrore = 0;
        private int _scroreAdd = 1;

        public void ScorePanel()
        {
            _scrore += _scroreAdd;
            _TextScore.text = _scrore.ToString();
        }
    }
}