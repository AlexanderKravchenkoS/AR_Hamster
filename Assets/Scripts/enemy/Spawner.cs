using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using game;

namespace enemy {
    public class Spawner : MonoBehaviour {
        private const int MIN_TIME = 3;
        private const int MAX_TIME = 7;
        private const float MIN_DISTANCE = 0.2f;
        private const float MAX_DISTANCE = 5f;
        public Score score;

        public Enemy enemyPrefab;

        public PlanesController planesController;

        private float nextSpawnTime;

        private void Start() {
            nextSpawnTime = Random.Range(MIN_TIME, MAX_TIME);
        }

        private void Update() {
            if (Time.time < nextSpawnTime) {
                return;
            }

            nextSpawnTime = Time.time + Random.Range(MIN_TIME, MAX_TIME);

            if (planesController.planes.Count == 0) {
                return;
            }

            var position = GetPosition();

            if (position == Camera.main.transform.position) {
                return;
            }

            var rotation = enemyPrefab.transform.rotation;

            var enemy = Instantiate(enemyPrefab, position, rotation);

            enemy.score = score;
        }

        private Vector3 GetPosition() {
            var tempPlanes = new List<ARPlane>(planesController.planes);

            int planeIndex;
            ARPlane plane;
            Vector3 newPosition;

            while (tempPlanes.Count != 0) {
                planeIndex = Random.Range(0, tempPlanes.Count);

                plane = tempPlanes[planeIndex];

                if (plane.transform.position.y > Camera.main.transform.position.y) {
                    tempPlanes.RemoveAt(planeIndex);
                    continue;
                }

                var posX = plane.center.x + Random.Range(-plane.size.x / 4, plane.size.x / 4);
                var posZ = plane.center.z + Random.Range(-plane.size.y / 4, plane.size.y / 4);

                newPosition = new Vector3(posX, plane.center.y, posZ);

                var distance = Vector3.Distance(Camera.main.transform.position, newPosition);

                if (distance < MIN_DISTANCE || distance > MAX_DISTANCE) {
                    tempPlanes.RemoveAt(planeIndex);
                    continue;
                }

                return newPosition;
            }

            return Camera.main.transform.position;
        }
    }
}