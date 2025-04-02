using UnityEngine;

namespace FlappyBird
{
    public class Pipe : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private float destroyXPosition = -10f;

        private void Update()
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

            if (transform.position.x < destroyXPosition)
            {
                Destroy(gameObject);
            }
        }
    }
}