using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float jumpForce = 10;
    [SerializeField] float groundCheckDistance = 1;

    Rigidbody rb;
    float forwardMovementInput;
    float rightMovementInput;
    bool onGround = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics.Raycast(transform.position, Vector3.up * -1, groundCheckDistance);

        forwardMovementInput = Input.GetAxis("Vertical");
        rightMovementInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        Debug.DrawLine(transform.position,
            transform.position + (transform.up * -groundCheckDistance),
            Color.red);

    }

    private void FixedUpdate()
    {
        Vector3 movementVector = ((transform.forward * forwardMovementInput) + (transform.right * rightMovementInput)).normalized * speed;
        movementVector.y = rb.velocity.y;

        rb.velocity = movementVector;
    }
}
