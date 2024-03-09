using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float jumpForce = 1.0f;

    float forwardMovementInput;
    float rightMovementInput;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        forwardMovementInput = Input.GetAxis("Vertical");
        rightMovementInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    private void FixedUpdate()
    {
        Vector3 movementVector = ((transform.forward * forwardMovementInput) + (transform.right * rightMovementInput)).normalized * speed;
        movementVector.y = rb.velocity.y;

        rb.velocity = movementVector;
    }
}
