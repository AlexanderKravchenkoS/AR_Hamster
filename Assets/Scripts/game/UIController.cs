using UnityEngine;
using UnityEngine.UI;

namespace game {
    public class UIController : MonoBehaviour {
        public Text pointsText;

        public Points points;

        private void Update() {
            pointsText.text = points.points.ToString();
        }
    }
}