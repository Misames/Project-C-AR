using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody _Rigidbody;
    public float forwardAcceleration = 7f;
    public float BackAcceleration = 3f;
    public float maxSpeed = 40f;
    public float turnStrenght = 180f;
    public float gravityforce = 15f;
    public float DragOnGround = 3f; 
    
    private float SpeedInput;
    private float TurnInput;
    private bool isGrounded;

    public LayerMask Ground;
    public float GroundRayLenght = 0.5f;
    public Transform groundRayPoint1;

    public Transform leftFrontWheel;
    public Transform rightFrontWheel;
    public Transform leftBackWheel;
    public Transform rightBackWheel;
    public float MaxWheelTurn = 25f;

    void Start()
    {
        _Rigidbody.transform.parent = null;
    }

    void Update()
    {
        SpeedInput = 0f;
        if (Input.GetAxis("Vertical") > 0)
        {
            SpeedInput = Input.GetAxis("Vertical") * forwardAcceleration  * 1000f;
        }else if (Input.GetAxis("Vertical") < 0)
        {
            SpeedInput = Input.GetAxis("Vertical") * BackAcceleration* 1000f;
            if (SpeedInput < 0)
            {
                SpeedInput = 0;
            }
        }

        if (isGrounded)
        {
            TurnInput = Input.GetAxis("Horizontal");
        
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f,
                TurnInput * turnStrenght * Time.deltaTime, 0f));
        }
        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x,(TurnInput*MaxWheelTurn),leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x,(TurnInput*MaxWheelTurn),rightFrontWheel.localRotation.eulerAngles.z);
        transform.position = _Rigidbody.transform.position;
    }

    private void FixedUpdate()
    {
        isGrounded = false;
        RaycastHit hit;
        if (Physics.Raycast(groundRayPoint1.position, -transform.up, out hit, GroundRayLenght, Ground))
        {
            isGrounded = true;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        if (isGrounded)
        {
            _Rigidbody.drag = DragOnGround;
            if (Mathf.Abs(SpeedInput) > 0)
                _Rigidbody.AddForce(transform.forward * SpeedInput);
        }
        else
        {
            _Rigidbody.drag = 0.1f;
            _Rigidbody.AddForce(Vector3.up * -gravityforce * 100f);
        }


    }
}
