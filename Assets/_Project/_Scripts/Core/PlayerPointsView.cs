using TMPro;
using UnityEngine;

namespace _Project._Scripts.Core
{
    public class PlayerPointsView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void SetPoints(int points)
        {
            _text.text = points.ToString();
        }
    }
}