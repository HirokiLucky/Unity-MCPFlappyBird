using UnityEngine;

namespace FlappyBird
{
    public class Bird : MonoBehaviour
    {
        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private float rotationSpeed = 10f;
        [SerializeField] private float maxRotationAngle = 35f;
        [SerializeField] private float minRotationAngle = -60f;

        private Rigidbody2D rb;
        private bool isDead = false;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (isDead) return;

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            // 鳥の回転を更新
            float angle = Mathf.Clamp(rb.velocity.y * rotationSpeed, minRotationAngle, maxRotationAngle);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        private void Jump()
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            isDead = true;
            GameManager.Instance.GameOver();
        }
    }
}