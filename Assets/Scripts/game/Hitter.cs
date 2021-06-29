using UnityEngine;
using enemy;

namespace game {
    public class Hitter : MonoBehaviour {
        private void Update() {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (!Physics.Raycast(ray, out hit)) {
                    return;
                }

                var enemy = hit.transform.gameObject.GetComponent<Enemy>();

                if (enemy == null) {
                    return;
                }

                Destroy(enemy.gameObject);
            }
        }
    }
}
