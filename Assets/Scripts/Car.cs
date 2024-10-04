using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] private float horsePower = 30.0f;
    [SerializeField] private WheelCollider[] wheels;
    [SerializeField] private GameObject centerOfMass;

    private float horizontalInput;
    private float forwardInput;

    private readonly int maxSpeed = 120;
    private readonly int minSpeed = 0;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.transform.position;
    }
    void FixedUpdate()
    {
        //print(speed);
        if (Input.GetKey(KeyCode.W) && speed < maxSpeed)
        {
            speed += Time.deltaTime * 8;
        }
        else if (Input.GetKey(KeyCode.S) && speed > minSpeed)
        {
            speed -= Time.deltaTime * 8;
        }
        else
        {
            if (speed > 5)
            {
                speed -= Time.deltaTime * 10;
            }
            else if (speed < 5)
            {
                speed += Time.deltaTime * 10;
            }
        }

        InfinityMovement();
        
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            if (forwardInput != 0)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
                rb.AddRelativeForce(Vector3.right * horizontalInput * horsePower);
            }
        }
    }


    private void InfinityMovement()
    {
        if (IsOnGround())
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * 1);
            rb.AddRelativeForce(Vector3.forward * 1 * horsePower);
        }
    }
    private bool IsOnGround()
    {
        int wheelsOnGround = 0;
        foreach (WheelCollider wheelCollider in wheels)
        {
            if (wheelCollider.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        return wheelsOnGround == 4 ? true : false;
    }
}
