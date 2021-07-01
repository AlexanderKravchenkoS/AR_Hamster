using game;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace fox {
    public class Spawner : MonoBehaviour {
        public Points points;
        public Fox foxPrefab;

        private ARRaycastManager raycastManager;
        private List<ARRaycastHit> hits = new List<ARRaycastHit>();

        private const int MIN_TIME = 2;
        private const int MAX_TIME = 8;
        private const float MAX_DISTANCE = 5f;
        private float nextSpawnTime;

        private void Start() {
            nextSpawnTime = Random.Range(MIN_TIME, MAX_TIME);
            raycastManager = FindObjectOfType<ARRaycastManager>();
        }

        private void Update() {

            var height = Screen.height;
            var width = Screen.width;

            var x = Random.Range(width / 4, width * 3 / 4);
            var y = Random.Range(height / 4, height * 3 / 4);

            var center = new Vector2(x, y);

            hits.Clear();
            raycastManager.Raycast(center, hits, TrackableType.PlaneWithinBounds);

            if (hits.Count <= 0) {
                return;
            }

            var dist = Vector3.Distance(Camera.main.transform.position, hits[0].pose.position);

            if (dist > MAX_DISTANCE) {
                return;
            }

            if (Time.time < nextSpawnTime) {
                return;
            }

            nextSpawnTime = Time.time + Random.Range(MIN_TIME, MAX_TIME);

            var fox = Instantiate(foxPrefab, hits[0].pose.position, hits[0].pose.rotation);

            fox.points = points;
        }
    }
}