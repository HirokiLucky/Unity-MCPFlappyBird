using UnityEngine;

namespace FlappyBird
{
    public class PipeSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject pipePrefab;
        [SerializeField] private float spawnInterval = 2f;
        [SerializeField] private float minHeight = -2f;
        [SerializeField] private float maxHeight = 2f;
        [SerializeField] private float xSpawnPosition = 10f;

        private float timer;

        private void Update()
        {
            if (GameManager.Instance.IsGameOver) return;

            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                SpawnPipe();
                timer = 0;
            }
        }

        private void SpawnPipe()
        {
            float randomHeight = Random.Range(minHeight, maxHeight);
            Vector3 spawnPosition = new Vector3(xSpawnPosition, randomHeight, 0);
            Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
        }
    }
}