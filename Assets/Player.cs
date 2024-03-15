
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


    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics.Raycast(transform.position, Vector3.up * -1, groundCheckDistance, environmentOnly);

        forwardMovementInput = Input.GetAxis("Vertical");
        rightMovementInput = Input.GetAxis("Horizontal");

        var movementVector = new Vector3(forwardMovementInput, 0, rightMovementInput);
        anim.SetFloat("speed", movementVector.magnitude);
        //anim.transform.forward = movementVector;

        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("jump");
        }

        Debug.DrawLine(transform.position, // start position
            transform.position + (transform.up * -groundCheckDistance), // end position
            Color.red);
    }

    private void FixedUpdate()
    {

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

    // Update score if collision with coin object
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            stats.currentScore++;
        }
    }

}
