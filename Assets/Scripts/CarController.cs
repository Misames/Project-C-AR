using UnityEngine;
using UnityEngine.Serialization;

public class CarController : MonoBehaviour
{
    public Rigidbody _Rigidbody;
    public float forwardAcceleration = 7f;
    public float BackAcceleration = 3f;
    public float maxSpeed = 40f;
    public float turnStrenght = 180f;
    public float gravityforce = 15f;
    public float DragOnGround = 3f;
    public Joystick joystickInput;
    
    private float SpeedInput;
    private float HorizontalInput;
    private bool isGrounded;

    public LayerMask Ground;
    public float GroundRayLenght = 0.2f;
    public Transform groundRayPoint1;

    public Transform leftFrontWheel;
    public Transform rightFrontWheel;
    public Transform leftBackWheel;
    public Transform rightBackWheel;
    public float MaxWheelTurn = 25f;

    
    void Update()
    {

        if (isGrounded)
        {
            HorizontalInput = joystickInput.Horizontal;
        
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f,HorizontalInput * turnStrenght * Time.deltaTime, 0f));
        }
        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x,(HorizontalInput*MaxWheelTurn),leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x,(HorizontalInput*MaxWheelTurn),rightFrontWheel.localRotation.eulerAngles.z);
    }

    private void FixedUpdate()
    {
        isGrounded = false;
        RaycastHit hit;
        if (Physics.Raycast(_Rigidbody.position, -transform.up, out hit, GroundRayLenght, Ground))
        {
            
            isGrounded = true;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
        

        if (isGrounded)
        {
            _Rigidbody.drag = DragOnGround;
            
            //if (Mathf.Abs(SpeedInput) > 0)
                //_Rigidbody.AddForce(transform.forward * SpeedInput);
        }
        else
        {
            _Rigidbody.drag = 0.1f;
            _Rigidbody.AddForce(Vector3.down * gravityforce );
        }
        
        
        


    }

    public void Accelerate()
    {   Debug.Log("acc");
        if(_Rigidbody.velocity.z<maxSpeed && isGrounded)
            _Rigidbody.AddForce(_Rigidbody.transform.forward * 10);
    }
    public void Brake()
    {
        Debug.Log("bra");
        if(_Rigidbody.velocity.z>-maxSpeed/2 && isGrounded)
            _Rigidbody.AddForce(_Rigidbody.transform.forward * -10);
    }
    
    
    
}
