using UnityEngine;
using game;

namespace enemy {
    public class Enemy : MonoBehaviour {
        public Score score;

        private float destroyTime;

        private const float LIFETIME = 10;

        private void Start() {
            destroyTime = Time.time + LIFETIME;
        }

        private void Update() {
            transform.LookAt(Camera.main.transform);

            if (Time.time < destroyTime) {
                return;
            }

            Destroy(gameObject);
        }

        private void OnDestroy() {
            if (Time.time > destroyTime) {
                score.MinusPoints();
            } else {
                score.PlusPoints();
            }
        }
    }
}