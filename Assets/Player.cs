
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] float jumpForce = 10;
    [SerializeField] float groundCheckDistance = 1;
    [SerializeField] LayerMask environmentOnly;
    [SerializeField] Animator anim;
    [SerializeField] int SceneGoTo = 0;
    [SerializeField] PlayerStats stats;

    Rigidbody rb;
    float forwardMovementInput;
    float rightMovementInput;
    bool onGround = false;

    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        stats.defaultStats();

    }

    // Update is called once per frame
    void Update()
    {
        // Raycasting ground check
        onGround = Physics.Raycast(transform.position, Vector3.up * -1, groundCheckDistance, environmentOnly);

        // Input
        forwardMovementInput = Input.GetAxis("Vertical");
        rightMovementInput = Input.GetAxis("Horizontal");

        // Update vectors for movement
        var movementVector = new Vector3(forwardMovementInput, 0, rightMovementInput);
        anim.SetFloat("speed", movementVector.magnitude);


        // Character jump logic
        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("jump");
        }

        // Raycasting visual representation
        Debug.DrawLine(transform.position, // start position
            transform.position + (transform.up * -groundCheckDistance), // end position
            Color.red);
    }

    private void FixedUpdate()
    {
        // Camera logic for following character
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camForward.Normalize();

        camRight.y = 0;
        camRight.Normalize();

        Vector3 forwardRelative = forwardMovementInput * camForward;
        Vector3 rightRelative = rightMovementInput * camRight;

        Vector3 movementVector = (forwardRelative + rightRelative) * speed;
        anim.transform.forward = movementVector;

        movementVector.y = rb.velocity.y;
        rb.velocity = movementVector;

    }

    // Update stats if collision with objects
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            stats.currentScore++;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            stats.currentHealth--;
        }
    }


}
