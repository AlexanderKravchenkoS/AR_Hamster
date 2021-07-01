using UnityEngine;
using game;

namespace fox {
    public class Fox : MonoBehaviour {
        public Points points;

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
                points.MinusPoints();
            } else {
                points.PlusPoints();
            }
        }
    }
}