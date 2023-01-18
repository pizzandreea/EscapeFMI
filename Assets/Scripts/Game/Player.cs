using UnityEngine;

namespace Game
{
    public class Player : MonoBehaviour
    {
        private const float RunningSpeed = 0.6f;
        private const float NormalSpeed = 0.3f;
        private const float SneakingSpeed = 0.15f;

        private BoxCollider2D _boxCollider;
        private float _movementSpeed = NormalSpeed;
        private Vector3 _moveDelta;
        private RaycastHit2D _hit;

        [SerializeField]
        private AudioSource walk;

        private bool isWalkingX = false;
        private bool isWalkingUp = false;
        private bool isWalkingDown = false;

        public Animator animator;

        // Start is called before the first frame update
        private void Start()
        {
            _boxCollider = GetComponent<BoxCollider2D>();
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            if (GameManager.Instance.isGameOver)
            {
                return;
            }

            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");

            // Reset moveDelta
            _moveDelta = new Vector3(x, y, 0);

            // Swap sprite direction, right or left
            if (_moveDelta.x > 0)
            {
                isWalkingX = true;
                animator.SetBool("isMovingX", true);
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            }
            else if (_moveDelta.x < 0)
            {
                isWalkingX = true;
                animator.SetBool("isMovingX", true);
                transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            }
            else
            {
                isWalkingX = false;
                animator.SetBool("isMovingX", false);
            }

            if (_moveDelta.y > 0 )
            {
                isWalkingUp = true;
                animator.SetBool("isMovingUp", true);
            }
            else
            {
                isWalkingUp = false;
                animator.SetBool("isMovingUp", false);
            }

            if(_moveDelta.y < 0)
            {
                isWalkingDown = true;
                animator.SetBool("isMovingDown", true);
            }
            else
            {
                isWalkingDown = false;
                animator.SetBool("isMovingDown", false);
            }
            if (isWalkingUp == true || isWalkingDown == true || isWalkingX == true)
            {
                if (!walk.isPlaying)
                        walk.Play();
            }
            else if (isWalkingUp == false || isWalkingDown == false || isWalkingX == false)
                walk.Stop();


            // Make sure nothing is blocking
            _hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(0, _moveDelta.y),
                Mathf.Abs(_movementSpeed * _moveDelta.y * Time.deltaTime), LayerMask.GetMask("Blocking"));
            if (_hit.collider == null)
            {
                transform.Translate(0, _movementSpeed * _moveDelta.y * Time.deltaTime, 0);
            }

            _hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(_moveDelta.x, 0),
                Mathf.Abs(_movementSpeed * _moveDelta.x * Time.deltaTime), LayerMask.GetMask("Blocking"));
            if (_hit.collider == null)
            {
                transform.Translate(_movementSpeed * _moveDelta.x * Time.deltaTime, 0, 0);
            }
        }

        private void Update()
        {
            if (GameManager.Instance.isGameOver)
            {
                return;
            }
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _movementSpeed = RunningSpeed;
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                _movementSpeed = SneakingSpeed;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftControl))
            {
                _movementSpeed = NormalSpeed;
            }
        }

        private void HandleDeath()
        {
            GameManager.Instance.isGameOver = true;
        }
    }
}