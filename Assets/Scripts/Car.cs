using System;
using UnityEngine;

public class Car : MonoBehaviour
{
    public static event Action GameOver;

    [SerializeField] private WheelCollider[] wheels;
    [SerializeField] public float speed = 5f;

    void Update()
    {
        if (IsOnGround())
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bot"))
        {
            GameOver?.Invoke();
        }
    }
}
