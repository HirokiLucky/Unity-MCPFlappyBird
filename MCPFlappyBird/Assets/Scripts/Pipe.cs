using UnityEngine;

namespace FlappyBird
{
    public class Pipe : MonoBehaviour
    {
        private float moveSpeed;
        private float destroyXPosition;

        public void Initialize(float speed, float destroyPos)
        {
            moveSpeed = speed;
            destroyXPosition = destroyPos;
        }

        private void Update()
        {
            if (GameManager.Instance.IsGameOver) return;

            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            if (transform.position.x < destroyXPosition)
            {
                Destroy(gameObject);
            }
        }
    }
}