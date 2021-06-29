using UnityEngine;

namespace game {
    public class Score : MonoBehaviour {
        public int points = 0;

        public void PlusPoints() {
            points++;
        }

        public void MinusPoints() {
            points--;
        }
    }
}