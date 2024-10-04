using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private WheelCollider[] wheels;
    [SerializeField] private float speed = 5f;

    private float horizontalInput;
    private void Awake()
    {
       
    }
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (IsOnGround())
        {
            transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
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
