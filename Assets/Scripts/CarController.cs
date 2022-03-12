using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float forwardAcceleration = 7f;
    public float backAcceleration = 3f;
    public float maxSpeed = 40f;
    public float turnStrenght = 180f;
    public float gravityforce = 15f;
    public float dragOnGround = 3f;

    private float speedInput;
    private float turnInput;
    private bool isGrounded;

    public LayerMask ground;
    public float GroundRayLenght = 0.5f;
    public Transform groundRayPoint1;

    public Transform leftFrontWheel;
    public Transform rightFrontWheel;
    public Transform leftBackWheel;
    public Transform rightBackWheel;
    public float maxWheelTurn = 25f;

    private void Start()
    {
        rigidBody.transform.parent = null;
    }

    private void Update()
    {
        speedInput = 0f;
        if (Input.GetAxis("Vertical") > 0)
            speedInput = Input.GetAxis("Vertical") * forwardAcceleration * 1000f;
        else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * backAcceleration * 1000f;
            if (speedInput < 0)
                speedInput = 0;
        }

        if (isGrounded)
        {
            turnInput = Input.GetAxis("Horizontal");
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f,
                turnInput * turnStrenght * Time.deltaTime, 0f));
        }

        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * maxWheelTurn), leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, (turnInput * maxWheelTurn), rightFrontWheel.localRotation.eulerAngles.z);
        transform.position = rigidBody.transform.position;
    }

    private void FixedUpdate()
    {
        isGrounded = false;
        RaycastHit hit;
        if (Physics.Raycast(groundRayPoint1.position, -transform.up, out hit, GroundRayLenght, ground))
        {
            isGrounded = true;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        if (isGrounded)
        {
            rigidBody.drag = dragOnGround;
            if (Mathf.Abs(speedInput) > 0)
                rigidBody.AddForce(transform.forward * speedInput);
        }
        else
        {
            rigidBody.drag = 0.1f;
            rigidBody.AddForce(Vector3.up * -gravityforce * 100f);
        }
    }
}
