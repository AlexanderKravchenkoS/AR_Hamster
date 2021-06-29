using UnityEngine;
using UnityEngine.UI;

namespace game {
    public class UIController : MonoBehaviour {
        public Text pointsText;
        public Text warningText;

        public PlanesController planesController;
        public Score score;

        private void Update() {
            if (planesController.planes.Count != 0) {
                warningText.enabled = false;
            } else {
                warningText.enabled = true;
            }

            pointsText.text = score.points.ToString();
        }
    }
}
