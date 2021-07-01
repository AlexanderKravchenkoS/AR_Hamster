using UnityEngine;
using fox;

namespace game {
    public class Hitter : MonoBehaviour {
        private void Update() {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (!Physics.Raycast(ray, out hit)) {
                    return;
                }

                var fox = hit.transform.gameObject.GetComponent<Fox>();

                if (fox == null) {
                    return;
                }

                Destroy(fox.gameObject);
            }
        }
    }
}