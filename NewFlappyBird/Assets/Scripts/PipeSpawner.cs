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
        [SerializeField] private float gapSize = 4f; // パイプ間の隙間サイズ

        private float timer;

        private void Update()
        {
            if (GameManager.Instance.IsGameOver) return;

            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                SpawnPipePair();
                timer = 0;
            }
        }

        private void SpawnPipePair()
        {
            float randomHeight = Random.Range(minHeight, maxHeight);
            
            // 下のパイプを生成
            GameObject lowerPipe = Instantiate(pipePrefab, new Vector3(xSpawnPosition, randomHeight - (gapSize/2), 0), Quaternion.identity);
            lowerPipe.transform.localScale = new Vector3(1f, 8f, 1f); // パイプの高さを8倍に
            
            // 上のパイプを生成
            GameObject upperPipe = Instantiate(pipePrefab, new Vector3(xSpawnPosition, randomHeight + (gapSize/2), 0), Quaternion.identity);
            upperPipe.transform.localScale = new Vector3(1f, 8f, 1f); // パイプの高さを8倍に
            
            // パイプをまとめるための親オブジェクトを作成
            GameObject pipeGroup = new GameObject("PipeGroup");
            lowerPipe.transform.parent = pipeGroup.transform;
            upperPipe.transform.parent = pipeGroup.transform;
            
            // 親オブジェクトにPipeスクリプトを追加
            Pipe pipeScript = pipeGroup.AddComponent<Pipe>();
        }
    }
}