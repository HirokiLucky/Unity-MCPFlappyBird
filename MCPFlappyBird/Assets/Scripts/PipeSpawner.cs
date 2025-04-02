using UnityEngine;

namespace FlappyBird
{
    public class PipeSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject pipePrefab;
        [SerializeField] private float spawnInterval = 2f;
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private float destroyXPosition = -10f;
        [SerializeField] private float spawnXPosition = 10f;
        [SerializeField] private float minYPosition = -2f;
        [SerializeField] private float maxYPosition = 2f;

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
            float randomY = Random.Range(minYPosition, maxYPosition);
            Vector3 spawnPosition = new Vector3(spawnXPosition, randomY, 0);
            GameObject pipe = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
            
            Pipe pipeScript = pipe.AddComponent<Pipe>();
            pipeScript.Initialize(moveSpeed, destroyXPosition);
        }
    }
}