using UnityEngine;

namespace Game
{
    public class Player : MonoBehaviour
    {
        private BoxCollider2D boxCollider;

        private Vector3 moveDelta;

        private float movementSpeed = 2.0f;

        private RaycastHit2D hit;

        // Start is called before the first frame update
        private void Start()
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            // Reset moveDelta
            moveDelta = new Vector3(x, y, 0);

            // Swap sprite direction, right or left

            if (moveDelta.x > 0)
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            else if (moveDelta.x < 0)
                transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);

            // Make sure nothing is blocking
            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y),
                Mathf.Abs(movementSpeed * moveDelta.y * Time.deltaTime), LayerMask.GetMask("Humans", "Blocking"));
            if (hit.collider == null)
            {
                transform.Translate(0, movementSpeed * moveDelta.y * Time.deltaTime, 0);
            }

            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0),
                Mathf.Abs(movementSpeed * moveDelta.x * Time.deltaTime), LayerMask.GetMask("Humans", "Blocking"));
            if (hit.collider == null)
            {
                transform.Translate(movementSpeed * moveDelta.x * Time.deltaTime, 0, 0);
            }
        }


        // Moving
        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movementSpeed = 3.0f;
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                movementSpeed = 1.0f;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftControl))
            {
                movementSpeed = 2.0f;
            }
        }
    }
}